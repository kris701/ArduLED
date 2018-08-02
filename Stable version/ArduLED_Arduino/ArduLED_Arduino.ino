#include <Adafruit_NeoPixel.h>

#define SplitS 32
#define InnersplitS SplitS + 2
#define InnersplitY 5
#define InputS 128
#define LEDStripsS 8
#define SeriesS 128
#define SeriesidS SeriesS
#define BaudRate 1000000

void setup() 
{
	Serial.begin(BaudRate, SERIAL_8N1);

	short NumberOfPixels[LEDStripsS];
	for (short i = 0; i < LEDStripsS; i++)
		NumberOfPixels[i] = 0;
	const uint8_t PixelTypes[2] = { NEO_GRB, NEO_RGB };
	const uint8_t PixelBitrates[2] = { NEO_KHZ800, NEO_KHZ400 };
	uint8_t PixelType[LEDStripsS];
	short Series[SeriesS];
	uint8_t SeriesID[SeriesidS];

	uint8_t PreviousColor[3] = { 255,255,255 };
	short SeriesIndex = 0;
	bool UsesCompression = false;
	short TotalLEDCount = 0;

	short Split[SplitS];

	Serial.write("R");

	while (true)
	{
		if (ReadSerial(&Split[0]))
		{
			if (Split[1] != 9999)
			{
				NumberOfPixels[Split[2]] = Split[1];
				PixelType[Split[2]] = PixelTypes[Split[3]] + PixelBitrates[Split[4]];
			}
			else
				break;
		}
	}

	while (true)
	{
		if (ReadSerial(&Split[0]))
		{
			if (Split[1] == 8888)
			{
				UsesCompression = true;
			}
			else
			{
				if (Split[1] != 9999)
				{
					if (UsesCompression)
					{
						Series[SeriesIndex] = Split[1];
						Series[SeriesIndex + 1] = Split[2];
						SeriesID[SeriesIndex / 2] = Split[3];
						SeriesIndex += 2;
					}
					else
					{
						Series[SeriesIndex] = Split[1];
						SeriesID[SeriesIndex] = Split[2];
						SeriesIndex++;
					}
				}
				else
					break;
			}
		}
	}

	Adafruit_NeoPixel LEDStrips[LEDStripsS] = {
		Adafruit_NeoPixel(NumberOfPixels[0], 0, PixelType[0]),
		Adafruit_NeoPixel(NumberOfPixels[1], 1, PixelType[1]),
		Adafruit_NeoPixel(NumberOfPixels[2], 2, PixelType[2]),
		Adafruit_NeoPixel(NumberOfPixels[3], 3, PixelType[3]),
		Adafruit_NeoPixel(NumberOfPixels[4], 4, PixelType[4]),
		Adafruit_NeoPixel(NumberOfPixels[5], 5, PixelType[5]),
		Adafruit_NeoPixel(NumberOfPixels[6], 6, PixelType[6]),
		Adafruit_NeoPixel(NumberOfPixels[7], 7, PixelType[7])
	};

	if (UsesCompression)
	{
		for (short i = 0; i < SeriesIndex; i += 2)
		{
			TotalLEDCount += abs(Series[i] - Series[i + 1]) + 1;
		}
	}

	for (short i = 0; i < LEDStripsS; i++)
	{
		if (LEDStrips[i].numPixels() > 0)
		{
			LEDStrips[i].begin();
			LEDStrips[i].show();
		}
	}

	ColorEntireStripFromTo(0, TotalLEDCount, 255, 255, 255, 5, UsesCompression, LEDStrips, SeriesIndex, Series, SeriesID, TotalLEDCount, 0, SeriesIndex);

	Run(LEDStrips, &Split[0], PreviousColor, SeriesIndex, Series, SeriesID, UsesCompression, TotalLEDCount);
}

void Run(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount)
{
	short FromID = 0;
	short ToID = _TotalLEDCount;
	short DiscardFromIndex = 0;
	short DiscardToIndex = _SeriesIndex / 2;
	short CountToFromID = _TotalLEDCount;

	while (true)
	{
		if (ReadSerial(&_Split[0]))
		{
			switch (_Split[0]) {
			case 'F':
				Mode_F(_LEDStrips, _Split, _PreviousColor, _SeriesIndex, _Series, _SeriesID, _UsesCompression, _TotalLEDCount, FromID, ToID, DiscardFromIndex, DiscardToIndex);
				break;
			case 'B':
				Mode_B(_LEDStrips, _Split, _PreviousColor, _SeriesIndex, _Series, _SeriesID, _UsesCompression, _TotalLEDCount, FromID, ToID, DiscardFromIndex, DiscardToIndex);
				break;
			case 'W':
				Mode_W(_LEDStrips, _Split, _SeriesIndex, _Series, _SeriesID, _UsesCompression, _TotalLEDCount, FromID, ToID, DiscardFromIndex, DiscardToIndex, CountToFromID);
				break;
			case 'I':
				Mode_I(_LEDStrips, _Split);
				break;
			case 'S':
				Mode_S(_LEDStrips, _Split, _PreviousColor, _SeriesIndex, _Series, _SeriesID, _UsesCompression, _TotalLEDCount, FromID, ToID, DiscardFromIndex, DiscardToIndex);
				break;
			case 'R':
				Mode_R(&DiscardFromIndex, &DiscardToIndex, &CountToFromID, _SeriesIndex, _Series, &FromID, &ToID, _UsesCompression, _TotalLEDCount, _Split);
				break;
			}
		}
	}
}

void Mode_F(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount, short _FromID, short _ToID, short _DiscardFromIndex, short _DiscardToIndex)
{
	float CurrentColor[3] = { 0,0,0 };
	float CurrentColorJump[3] = { 0,0,0 };

	for (short i = 0; i < 3; i++)
	{
		CurrentColorJump[i] = (((float)_PreviousColor[i] - (float)_Split[i + 1]) * ((float)_Split[5] / (float)100));
		CurrentColor[i] = _PreviousColor[i];
	}

	while ((CurrentColor[0] == _Split[1]) + (CurrentColor[1] == _Split[2]) + (CurrentColor[2] == _Split[3]) < 3)
	{
		for (short i = 0; i < 3; i++)
		{
			CurrentColor[i] -= CurrentColorJump[i];
			CurrentColorJump[i] = ((CurrentColor[i] - (float)_Split[i + 1]) * ((float)_Split[5] / (float)100));
			if (CurrentColor[i] < 0)
				CurrentColor[i] = 0;
			if (CurrentColor[i] > 255)
				CurrentColor[i] = 255;
			if (CurrentColorJump[i] < 0)
			{
				if (CurrentColorJump[i] >= -1)
					CurrentColor[i] = _Split[i + 1];
			}
			else
			{
				if (CurrentColorJump[i] <= 1)
					CurrentColor[i] = _Split[i + 1];
			}
		}
		ColorEntireStripFromTo(_FromID, _ToID, CurrentColor[0], CurrentColor[1], CurrentColor[2], 0, _UsesCompression, _LEDStrips, _SeriesIndex, _Series, _SeriesID, _TotalLEDCount, _DiscardFromIndex, _DiscardToIndex);

		for (short i = 0; i < LEDStripsS; i++)
		{
			if (_LEDStrips[i].numPixels() > 0)
			{
				_LEDStrips[i].show();
			}
		}

		delay(_Split[4]);
	}
	_PreviousColor[0] = _Split[1];
	_PreviousColor[1] = _Split[2];
	_PreviousColor[2] = _Split[3];

}

void Mode_B(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount, short _FromID, short _ToID, short _DiscardFromIndex, short _DiscardToIndex)
{
	ColorEntireStripFromTo(_FromID, _ToID, _PreviousColor[0] * ((float)_Split[1] / (float)100), _PreviousColor[1] * ((float)_Split[2] / (float)100), _PreviousColor[2] * ((float)_Split[3] / (float)100), 0, _UsesCompression, _LEDStrips, _SeriesIndex, _Series, _SeriesID, _TotalLEDCount, _DiscardFromIndex, _DiscardToIndex);

	for (short i = 0; i < LEDStripsS; i++)
	{
		if (_LEDStrips[i].numPixels() > 0)
		{
			_LEDStrips[i].show();
		}
	}
}

void Mode_W(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount, short _FromID, short _ToID, short _DiscardFromIndex, short _DiscardToIndex, short _CountToFromID)
{
	if (_UsesCompression)
	{
		if (_ToID > _FromID)
		{
			short CurrentIndex = _TotalLEDCount;
			for (short i = _SeriesIndex - 2; i >= _DiscardFromIndex; i -= 2)
			{
				if (i <= _DiscardToIndex)
				{
					if (_Series[i + 1] > _Series[i])
					{
						for (short j = _Series[i + 1]; j >= _Series[i]; j--)
						{
							if (CurrentIndex - (_Series[i + 1] - j) + 1 >= _FromID)
							{
								if (CurrentIndex - (_Series[i + 1] - j) - 1 <= _ToID)
								{
									if (j == _Series[i])
									{
										if (i != 0)
										{
											if (_Series[(i - 2) + 1] > _Series[i - 2])
												_LEDStrips[_SeriesID[i / 2]].setPixelColor(j, _LEDStrips[_SeriesID[(i - 2) / 2]].getPixelColor(_Series[(i - 2) + 1]));
											else
												_LEDStrips[_SeriesID[i / 2]].setPixelColor(j, _LEDStrips[_SeriesID[(i - 2) / 2]].getPixelColor(_Series[(i - 2) + 1]));
										}
									}
									else
										_LEDStrips[_SeriesID[i / 2]].setPixelColor(j, _LEDStrips[_SeriesID[i / 2]].getPixelColor(j - 1));
								}
							}
							else
								break;
						}
					}
					else
					{
						for (short j = _Series[i + 1]; j <= _Series[i]; j++)
						{
							if (CurrentIndex - (j - _Series[i + 1]) + 1 >= _FromID)
							{
								if (CurrentIndex - (j - _Series[i + 1]) - 1 <= _ToID)
								{
									if (j == _Series[i])
									{
										if (i != 0)
										{
											if (_Series[(i - 2) + 1] > _Series[i - 2])
												_LEDStrips[_SeriesID[i / 2]].setPixelColor(j, _LEDStrips[_SeriesID[(i - 2) / 2]].getPixelColor(_Series[(i - 2) + 1]));
											else
												_LEDStrips[_SeriesID[i / 2]].setPixelColor(j, _LEDStrips[_SeriesID[(i - 2) / 2]].getPixelColor(_Series[(i - 2) + 1]));
										}
									}
									else
										_LEDStrips[_SeriesID[i / 2]].setPixelColor(j, _LEDStrips[_SeriesID[i / 2]].getPixelColor(j + 1));
								}
							}
							else
								break;
						}
					}
				}
				CurrentIndex -= abs(_Series[i] - _Series[i + 1]) + 1;
			}

			if (_Series[_DiscardFromIndex + 1] > _Series[_DiscardFromIndex])
				_LEDStrips[_SeriesID[_DiscardFromIndex / 2]].setPixelColor(_Series[_DiscardFromIndex + 1] - (_CountToFromID - _FromID + 1), _Split[1], _Split[2], _Split[3]);
			else
				_LEDStrips[_SeriesID[_DiscardFromIndex / 2]].setPixelColor(_Series[_DiscardFromIndex + 1] + (_CountToFromID - _FromID - 1), _Split[1], _Split[2], _Split[3]);
		}
	}
	else
	{
		for (short i = _ToID; i >= _FromID; i--)
		{
			if (i == _FromID)
			{
				_LEDStrips[_SeriesID[i]].setPixelColor(_Series[i], _Split[1], _Split[2], _Split[3]);
			}
			else
			{
				_LEDStrips[_SeriesID[i]].setPixelColor(_Series[i], _LEDStrips[_SeriesID[i - 1]].getPixelColor(_Series[i - 1]));
			}
		}
	}

	for (short i = 0; i < LEDStripsS; i++)
	{
		if (_LEDStrips[i].numPixels() > 0)
		{
			_LEDStrips[i].show();
		}
	}
}

void Mode_I(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS])
{
	_LEDStrips[_Split[1]].setPixelColor(_Split[2], _Split[3], _Split[4], _Split[5]);
	_LEDStrips[_Split[1]].show();
}

void Mode_S(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount, short _FromID, short _ToID, short _DiscardFromIndex, short _DiscardToIndex)
{
	if (_UsesCompression)
	{
		ColorEntireStripFromTo(_FromID, _ToID, 0, 0, 0, 0, _UsesCompression, _LEDStrips, _SeriesIndex, _Series, _SeriesID, _TotalLEDCount, _DiscardFromIndex, _DiscardToIndex);

		short Count = 4;
		short CurrentSplitIndex = 0;
		short CurrentIndex = 0;

		for (short j = 0; j <= _DiscardToIndex; j += 2)
		{
			if (j >= _DiscardFromIndex && j <= _DiscardToIndex)
			{
				if (_Series[j + 1] > _Series[j])
				{
					for (int i = _Series[j] + abs(CurrentSplitIndex - CurrentIndex); i <= _Series[j + 1] + _Split[1]; i += _Split[1])
					{
						if (i >= _Series[j])
						{
							if (CurrentSplitIndex >= _FromID)
							{
								if (CurrentSplitIndex + _Split[1] <= _ToID)
								{
									for (short l = i; l < i + _Split[Count]; l++)
									{
										if (l > _Series[j + 1])
										{
											if (_Series[(j + 2) + 1] > _Series[(j + 2)])
												_LEDStrips[_SeriesID[(j + 2) / 2]].setPixelColor(_Series[j + 2] + abs(_Series[j + 1] - l) - 1, _PreviousColor[0], _PreviousColor[1], _PreviousColor[2]);
											else
												_LEDStrips[_SeriesID[(j + 2) / 2]].setPixelColor(_Series[j + 2] - abs(_Series[j + 1] - l) + 1, _PreviousColor[0], _PreviousColor[1], _PreviousColor[2]);
										}
										else
											_LEDStrips[_SeriesID[j / 2]].setPixelColor(l, _PreviousColor[0], _PreviousColor[1], _PreviousColor[2]);
									}
								}
							}
						}
						CurrentSplitIndex += _Split[1];
						Count++;
						if (Count > SplitS)
							break;
					}
				}
				else
				{
					for (int i = _Series[j] - abs(CurrentSplitIndex - CurrentIndex); i >= _Series[j + 1] - _Split[1]; i -= _Split[1])
					{
						if (i <= _Series[j])
						{
							if (CurrentSplitIndex >= _FromID)
							{
								if (CurrentSplitIndex + _Split[1] <= _ToID)
								{
									for (short l = i; l > i - _Split[Count]; l--)
									{
										if (l < _Series[j + 1])
										{
											if (_Series[(j + 2) + 1] > _Series[(j + 2)])
												_LEDStrips[_SeriesID[(j + 2) / 2]].setPixelColor(_Series[j + 2] + abs(_Series[j + 1] - l) - 1, _PreviousColor[0], _PreviousColor[1], _PreviousColor[2]);
											else
												_LEDStrips[_SeriesID[(j + 2) / 2]].setPixelColor(_Series[j + 2] - abs(_Series[j + 1] - l) + 1, _PreviousColor[0], _PreviousColor[1], _PreviousColor[2]);
										}
										else
											_LEDStrips[_SeriesID[j / 2]].setPixelColor(l, _PreviousColor[0], _PreviousColor[1], _PreviousColor[2]);
									}
								}
							}
						}
						CurrentSplitIndex += _Split[1];
						Count++;
						if (Count > SplitS)
							break;
					}
				}
			}
			else
			{
				CurrentSplitIndex += ((abs(_Series[j] - _Series[j + 1]) + 1) / 5) * 5;
				Count += (abs(_Series[j] - _Series[j + 1]) + 1) / 5;
			}
			CurrentIndex += abs(_Series[j] - _Series[j + 1]) + 1;
		}
	}
	else
	{
		short Count = 2;

		for (short i = _FromID; i < _ToID; i++)
		{
			_LEDStrips[_SeriesID[i]].setPixelColor(_Series[i], 0, 0, 0);
		}
		for (short i = _FromID; i < _ToID; i += _Split[1])
		{
			for (short j = 0; j < _Split[Count]; j++)
			{
				_LEDStrips[_SeriesID[i + j]].setPixelColor(_Series[i + j], _PreviousColor[0], _PreviousColor[1], _PreviousColor[2]);
			}
			Count++;
			if (Count > SplitS)
				break;
		}
	}
	for (short i = 0; i < LEDStripsS; i++)
	{
		if (_LEDStrips[i].numPixels() > 0)
		{
			_LEDStrips[i].show();
		}
	}
}

void Mode_R(short *_DiscardFromIndex, short *_DiscardToIndex, short *_CountToFromID, short _SeriesIndex, short _Series[SeriesS], short *_FromID, short *_ToID, bool _UsesCompression, short _TotalLEDCount, short _Split[SplitS])
{
	*_CountToFromID = _TotalLEDCount;

	if (_UsesCompression)
	{
		*_FromID = 0;
		*_ToID = _TotalLEDCount;

		if (_Split[1] > 0)
			if (_Split[1] < _TotalLEDCount)
				*_FromID = _Split[1];
		if (_Split[2] >= 0)
			if (_Split[2] <= _TotalLEDCount)
				*_ToID = _Split[2];

		for (short i = _SeriesIndex - 2; i >= 0; i -= 2)
		{
			*_CountToFromID -= abs(_Series[i] - _Series[i + 1]) + 1;
			if (*_CountToFromID <= *_ToID)
			{
				*_DiscardToIndex = i;
				break;
			}
		}

		*_CountToFromID = 0;
		for (short i = 0; i <= _SeriesIndex - 2; i += 2)
		{
			*_CountToFromID += abs(_Series[i] - _Series[i + 1]) + 1;
			if (*_CountToFromID >= *_FromID)
			{
				*_DiscardFromIndex = i;
				break;
			}
		}
	}
	else
	{
		*_FromID = 0;
		*_ToID = _SeriesIndex;

		if (_Split[1] > 0)
			if (_Split[1] <= _SeriesIndex)
				*_FromID = _Split[1];
		if (_Split[2] >= 0)
			if (_Split[2] <= _SeriesIndex)
				*_ToID = _Split[2];
	}
}

void ColorEntireStripFromTo(short _FromID, short _ToID, short _Red, short _Green, short _Blue, short _Delay, bool _UsesCompression, Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], short _TotalLEDCount, short _DiscardFromIndex, short _DiscardToIndex)
{
	if (_UsesCompression)
	{
		short CurrentIndex = 0;
		for (short j = 0; j <= _DiscardToIndex; j += 2)
		{
			if (j >= _DiscardFromIndex && j <= _DiscardToIndex)
			{
				if (_Series[j + 1] > _Series[j])
				{
					for (short i = 0; i <= abs(_Series[j] - _Series[j + 1]); i++)
					{
						if (CurrentIndex + i >= _FromID)
						{
							if (CurrentIndex + i <= _ToID)
							{
								_LEDStrips[_SeriesID[j / 2]].setPixelColor((_Series[j] + i), _Red, _Green, _Blue);
								if (_Delay > 0)
								{
									_LEDStrips[_SeriesID[j / 2]].show();
									delay(_Delay);
								}
							}
						}
					}
				}
				else
				{
					for (short i = abs(_Series[j] - _Series[j + 1]); i >= 0; i--)
					{
						if (CurrentIndex + (abs(_Series[j] - _Series[j + 1]) - i) >= _FromID)
						{
							if (CurrentIndex + (abs(_Series[j] - _Series[j + 1]) - i) <= _ToID)
							{
								_LEDStrips[_SeriesID[j / 2]].setPixelColor((_Series[j + 1] + i), _Red, _Green, _Blue);
								if (_Delay > 0)
								{
									_LEDStrips[_SeriesID[j / 2]].show();
									delay(_Delay);
								}
							}
						}
					}
				}
			}
			CurrentIndex += abs(_Series[j] - _Series[j + 1]) + 1;
		}
	}
	else
	{
		for (short i = _FromID; i < _ToID; i++)
		{
			_LEDStrips[_SeriesID[i]].setPixelColor(_Series[i], _Red, _Green, _Blue);
			if (_Delay > 0)
			{
				_LEDStrips[_SeriesID[i]].show();
				delay(_Delay);
			}
		}
	}
}

bool ReadSerial(short *_Split)
{
	if (Serial.available() > 0)
	{
		char Input[InputS];
		char InnerSplit[InnersplitS][InnersplitY];

		for (short i = 0; i < InputS; i++)
			Input[i] = 0;
		for (short i = 0; i < SplitS; i++)
			_Split[i] = 0;
		for (short i = 0; i < InnersplitS; i++)
			for (short j = 0; j < InnersplitY; j++)
				InnerSplit[i][j] = 0;

		short Step = 0;

		while (true)
		{
			if (Serial.available() > 0)
			{
				Input[Step] = (char)Serial.read();
				if (Input[Step] == 'E')
					break;
				Step++;
				if (Step >= InputS)
				{
					Serial.read();
					return false;
				}
			}
		}

		short CurrentPos = 0;
		short CurrentStep = 0;
		for (short i = 0; i < InputS; i++)
		{
			if (Input[i] == ';')
			{
				if (((String)InnerSplit[CurrentPos]).toInt() == -1)
				{
					_Split[CurrentPos] = ((String)InnerSplit[CurrentPos]).toInt();
				}
				else
				{
					if (IsDigitsOnly((String)InnerSplit[CurrentPos]))
						_Split[CurrentPos] = ((String)InnerSplit[CurrentPos]).toInt();
					else
						_Split[CurrentPos] = InnerSplit[CurrentPos][0];
				}
				CurrentStep = 0;
				CurrentPos++;
				if (CurrentPos >= SplitS)
					return false;
			}
			else
			{
				if (Input[i] == 'E')
					break;
				if (Input[i] == 10)
					continue;

				InnerSplit[CurrentPos][CurrentStep] = Input[i];
				CurrentStep++;

				if (CurrentStep >= InnersplitY)
					return false;
			}
		}

		return true;
	}
	return false;
}

bool IsDigitsOnly(String _InputString)
{
	for (short i = 0; i < _InputString.length(); i++)
	{
		if (_InputString[i] < '0' || _InputString[i] > '9')
			return false;
	}

	return true;
}

void loop() { }