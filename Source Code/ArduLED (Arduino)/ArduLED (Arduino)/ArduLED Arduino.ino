#include <Adafruit_NeoPixel.h>

#define SplitS 128
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

	ColorEntireStripFromTo(0, TotalLEDCount, 255, 255, 255, 5, UsesCompression, LEDStrips, SeriesIndex, Series, SeriesID, TotalLEDCount, -2, SeriesIndex, 0);

	Run(LEDStrips, &Split[0], PreviousColor, SeriesIndex, Series, SeriesID, UsesCompression, TotalLEDCount);
}

void Run(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount)
{
	short FromID = 0;
	short ToID = _TotalLEDCount;
	short DiscardFromIndex = 0;
	short DiscardToIndex = _SeriesIndex / 2;
	short CountToID = _TotalLEDCount;
	short CountFromID = 0;
	short ShowFromPin = 8;
	short ShowToPin = 0;

	while (true)
	{
		if (ReadSerial(&_Split[0]))
		{
			switch (_Split[0]) {
			case 1:
				Mode_F(_LEDStrips, _Split, _PreviousColor, _SeriesIndex, _Series, _SeriesID, _UsesCompression, _TotalLEDCount, FromID, ToID, DiscardFromIndex, DiscardToIndex, CountFromID, ShowFromPin, ShowToPin);
				break;
			case 2:
				Mode_B(_LEDStrips, _Split, _PreviousColor, _SeriesIndex, _Series, _SeriesID, _UsesCompression, _TotalLEDCount, FromID, ToID, DiscardFromIndex, DiscardToIndex, CountFromID, ShowFromPin, ShowToPin);
				break;
			case 3:
				Mode_W(_LEDStrips, _Split, _SeriesIndex, _Series, _SeriesID, _UsesCompression, _TotalLEDCount, FromID, ToID, DiscardFromIndex, DiscardToIndex, CountFromID, CountToID, ShowFromPin, ShowToPin);
				break;
			case 4:
				Mode_I(_LEDStrips, _Split);
				break;
			case 5:
				Mode_S(_LEDStrips, _Split, _PreviousColor, _SeriesIndex, _Series, _SeriesID, _UsesCompression, _TotalLEDCount, FromID, ToID, DiscardFromIndex, DiscardToIndex, CountFromID, ShowFromPin, ShowToPin);
				break;
			case 6:
				Mode_R(&DiscardFromIndex, &DiscardToIndex, &CountFromID, &CountToID, _SeriesIndex, _LEDStrips, _Series, _SeriesID, &FromID, &ToID, _UsesCompression, _TotalLEDCount, _Split, &ShowFromPin, &ShowToPin);
				break;
			case 7:
				Mode_A(_LEDStrips, _Split, _SeriesIndex, _Series, _SeriesID, _UsesCompression, _TotalLEDCount, FromID, ToID, DiscardFromIndex, DiscardToIndex, CountFromID, ShowFromPin, ShowToPin);
				break;
			}
		}
	}
}

void Mode_F(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount, short _FromID, short _ToID, short _DiscardFromIndex, short _DiscardToIndex, short _CountFromID, short _ShowFromPin, short _ShowToPin)
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
		ColorEntireStripFromTo(_FromID, _ToID, CurrentColor[0], CurrentColor[1], CurrentColor[2], 0, _UsesCompression, _LEDStrips, _SeriesIndex, _Series, _SeriesID, _TotalLEDCount, _DiscardFromIndex, _DiscardToIndex, _CountFromID);

		for (short i = _ShowFromPin; i <= _ShowToPin; i++)
		{
			if (_LEDStrips[i].numPixels() > 0)
				_LEDStrips[i].show();
		}

		delay(_Split[4]);
	}
	_PreviousColor[0] = _Split[1];
	_PreviousColor[1] = _Split[2];
	_PreviousColor[2] = _Split[3];

}

void Mode_B(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount, short _FromID, short _ToID, short _DiscardFromIndex, short _DiscardToIndex, short _CountFromID, short _ShowFromPin, short _ShowToPin)
{
	ColorEntireStripFromTo(_FromID, _ToID, _PreviousColor[0] * ((float)_Split[1] / (float)100), _PreviousColor[1] * ((float)_Split[2] / (float)100), _PreviousColor[2] * ((float)_Split[3] / (float)100), 0, _UsesCompression, _LEDStrips, _SeriesIndex, _Series, _SeriesID, _TotalLEDCount, _DiscardFromIndex, _DiscardToIndex, _CountFromID);

	for (short i = _ShowFromPin; i <= _ShowToPin; i++)
	{
		if (_LEDStrips[i].numPixels() > 0)
			_LEDStrips[i].show();
	}
}

void Mode_W(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount, short _FromID, short _ToID, short _DiscardFromIndex, short _DiscardToIndex, short _CountFromID, short _CountToID, short _ShowFromPin, short _ShowToPin)
{
	if (_UsesCompression)
	{
		if (_ToID > _FromID)
		{
			short CurrentIndex = _CountToID;
			for (short i = _DiscardToIndex; i >= _DiscardFromIndex; i -= 2)
			{
				if (_Series[i + 1] > _Series[i])
				{
					for (short j = _Series[i + 1]; j >= _Series[i]; j--)
					{
						if (CurrentIndex - (_Series[i + 1] - j) >= _FromID)
						{
							if (CurrentIndex - (_Series[i + 1] - j) <= _ToID)
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
						if (CurrentIndex - (j - _Series[i + 1]) >= _FromID)
						{
							if (CurrentIndex - (j - _Series[i + 1]) <= _ToID)
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
				CurrentIndex -= abs(_Series[i] - _Series[i + 1]) + 1;
			}

			if (_Series[_DiscardFromIndex + 1] > _Series[_DiscardFromIndex])
				_LEDStrips[_SeriesID[_DiscardFromIndex / 2]].setPixelColor(_Series[_DiscardFromIndex + 1] - (_CountFromID - _FromID + 1), _Split[1], _Split[2], _Split[3]);
			else
				_LEDStrips[_SeriesID[_DiscardFromIndex / 2]].setPixelColor(_Series[_DiscardFromIndex + 1] + (_CountFromID - _FromID - 1), _Split[1], _Split[2], _Split[3]);
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

	for (short i = _ShowFromPin; i <= _ShowToPin; i++)
	{
		if (_LEDStrips[i].numPixels() > 0)
			_LEDStrips[i].show();
	}
}

void Mode_I(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS])
{
	_LEDStrips[_Split[1]].setPixelColor(_Split[2], _Split[3], _Split[4], _Split[5]);
	_LEDStrips[_Split[1]].show();
}

void Mode_S(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount, short _FromID, short _ToID, short _DiscardFromIndex, short _DiscardToIndex, short _CountFromID, short _ShowFromPin, short _ShowToPin)
{
	if (_UsesCompression)
	{
		ColorEntireStripFromTo(_FromID, _ToID, 0, 0, 0, 0, _UsesCompression, _LEDStrips, _SeriesIndex, _Series, _SeriesID, _TotalLEDCount, _DiscardFromIndex, _DiscardToIndex, _CountFromID);

		short Count = 4 + _DiscardFromIndex;
		short CurrentSplitIndex = _DiscardFromIndex * _Split[1];
		short CurrentIndex = _CountFromID - (abs(_Series[_DiscardFromIndex] - _Series[_DiscardFromIndex + 1]) + 1);

		for (short j = _DiscardFromIndex; j <= _DiscardToIndex; j += 2)
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

	for (short i = _ShowFromPin; i <= _ShowToPin; i++)
	{
		if (_LEDStrips[i].numPixels() > 0)
			_LEDStrips[i].show();
	}
}

void Mode_R(short *_DiscardFromIndex, short *_DiscardToIndex, short *_CountFromID, short *_CountToID, short _SeriesIndex, Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], short *_FromID, short *_ToID, bool _UsesCompression, short _TotalLEDCount, short _Split[SplitS], short *_ShowFromPin, short *_ShowToPin)
{
	if (_UsesCompression)
	{
		*_FromID = 0;
		*_ToID = _TotalLEDCount;
		*_CountToID = _TotalLEDCount;
		*_CountFromID = 0;
		*_ShowFromPin = 8;
		*_ShowToPin = 0;

		if (_Split[1] > 0)
			if (_Split[1] < _TotalLEDCount)
				*_FromID = _Split[1];
		if (_Split[2] >= 0)
			if (_Split[2] <= _TotalLEDCount)
				*_ToID = _Split[2];

		for (short i = _SeriesIndex - 2; i >= 0; i -= 2)
		{
			*_CountToID -= abs(_Series[i] - _Series[i + 1]) + 1;
			if (*_CountToID <= *_ToID - 1)
			{
				*_CountToID += abs(_Series[i] - _Series[i + 1]) + 1;
				*_DiscardToIndex = i;
				break;
			}
		}

		for (short i = 0; i <= _SeriesIndex - 2; i += 2)
		{
			*_CountFromID += abs(_Series[i] - _Series[i + 1]) + 1;
			if (*_CountFromID >= *_FromID)
			{
				*_DiscardFromIndex = i;
				break;
			}
		}

		for (short i = *_DiscardFromIndex; i <= *_DiscardToIndex; i += 2)
		{
			if (_SeriesID[i / 2] < *_ShowFromPin)
				*_ShowFromPin = _SeriesID[i / 2];
			if (_SeriesID[i / 2] > *_ShowToPin)
				*_ShowToPin = _SeriesID[i / 2];
		}
	}
	else
	{
		*_FromID = 0;
		*_ToID = _SeriesIndex;
		*_ShowFromPin = 8;
		*_ShowToPin = 0;

		for (short i = 0; i <= LEDStripsS; i++)
		{
			if (_LEDStrips[i].numPixels() > 0)
			{
				if (i < *_ShowFromPin)
					*_ShowFromPin = i;
				if (i > *_ShowToPin)
					*_ShowToPin = i;
			}
		}

		if (_Split[1] > 0)
			if (_Split[1] <= _SeriesIndex)
				*_FromID = _Split[1];
		if (_Split[2] >= 0)
			if (_Split[2] <= _SeriesIndex)
				*_ToID = _Split[2];
	}
}

void Mode_A(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], bool _UsesCompression, short _TotalLEDCount, short _FromID, short _ToID, short _DiscardFromIndex, short _DiscardToIndex, short _CountFromID, short _ShowFromPin, short _ShowToPin)
{
	if (_UsesCompression)
	{
		short Count = 4;
		short CurrentIndex = _CountFromID - (abs(_Series[_DiscardFromIndex] - _Series[_DiscardFromIndex + 1]) + 1);;

		for (short j = _DiscardFromIndex; j <= _DiscardToIndex; j += 2)
		{
			if (_Series[j + 1] > _Series[j])
			{
				for (int i = _Series[j]; i <= _Series[j + 1]; i++)
				{
					if (CurrentIndex + (i - _Series[j]) >= _Split[1])
					{
						if (CurrentIndex + (i - _Series[j]) <= _Split[2])
						{
							for (int l = i; l <= i + _Split[3]; l++)
							{
								if (CurrentIndex + (l - _Series[j]) >= _Split[1])
								{
									if (CurrentIndex + (l - _Series[j]) <= _Split[2])
									{
										_LEDStrips[_SeriesID[j / 2]].setPixelColor(l, ((255 / 9) * (_Split[Count])), ((255 / 9) * (_Split[Count + 1])), ((255 / 9) * (_Split[Count + 2])));
									}
								}
							}
							Count += 3;
							i += _Split[3] - 1;
						}
					}
				}
			}
			else
			{
				for (int i = _Series[j]; i >= _Series[j + 1]; i--)
				{
					if (CurrentIndex + (_Series[j] - i) >= _Split[1])
					{
						if (CurrentIndex + (_Series[j] - i) <= _Split[2])
						{
							for (int l = i; l >= i - _Split[3]; l--)
							{
								if (CurrentIndex + (_Series[j] - l) >= _Split[1])
								{
									if (CurrentIndex + (_Series[j] - l) <= _Split[2])
									{
										_LEDStrips[_SeriesID[j / 2]].setPixelColor(l, ((255 / 9) * (_Split[Count])), ((255 / 9) * (_Split[Count + 1])), ((255 / 9) * (_Split[Count + 2])));
									}
								}
							}
							Count += 3;
							i -= _Split[3] - 1;
						}
					}
				}
			}
			CurrentIndex += abs(_Series[j] - _Series[j + 1]) + 1;
		}
	}
	else
	{

	}

	for (short i = _ShowFromPin; i <= _ShowToPin; i++)
	{
		if (_LEDStrips[i].numPixels() > 0)
			_LEDStrips[i].show();
	}
}

void ColorEntireStripFromTo(short _FromID, short _ToID, short _Red, short _Green, short _Blue, short _Delay, bool _UsesCompression, Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _SeriesIndex, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS], short _TotalLEDCount, short _DiscardFromIndex, short _DiscardToIndex, short _CountFromID)
{
	if (_UsesCompression)
	{
		short CurrentIndex = _CountFromID - (abs(_Series[_DiscardFromIndex] - _Series[_DiscardFromIndex + 1]) + 1);;
		for (short j = _DiscardFromIndex; j <= _DiscardToIndex; j += 2)
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
		for (short i = 0; i < SplitS; i++)
			_Split[i] = 0;

		short Step = 0;

		while (true)
		{
			if (Serial.available() > 4)
			{
				int Value = Serial.parseInt();
				if (Value == -10)
				{
					Serial.read();
					break;
				}
				_Split[Step] = Value;
				Step++;
				if (Step >= SplitS)
				{
					Serial.read();
					return false;
				}
			}
		}

		return true;
	}
	return false;
}

void loop() { }