#include <Adafruit_NeoPixel.h>

#define SplitS 32
#define InnersplitS SplitS + 2
#define InnersplitY 5
#define InputS 128
#define LEDStripsS 8
#define SeriesS 128
#define SeriesidS SeriesS
#define SeriesAmbiLightS SeriesS
#define BaudRate 1000000

void setup() 
{
	Serial.begin(BaudRate, SERIAL_8N1);

	short NumberOfPixels[LEDStripsS];
	for (int i = 0; i < LEDStripsS; i++)
		NumberOfPixels[i] = 0;
	const uint8_t PixelTypes[2] = { NEO_GRB, NEO_RGB };
	const uint8_t PixelBitrates[2] = { NEO_KHZ800, NEO_KHZ400 };
	uint8_t PixelType[LEDStripsS];
	short Series[SeriesS];
	uint8_t SeriesID[SeriesidS];

	uint8_t PreviousColor[3] = { 255,255,255 };
	short TotalSeriesCount = 0;

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
			if (Split[1] != 9999)
			{
				Series[TotalSeriesCount] = Split[1];
				SeriesID[TotalSeriesCount] = Split[2];
				TotalSeriesCount++;
			}
			else
				break;
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

	for (int i = 0; i < LEDStripsS; i++)
	{
		if (LEDStrips[i].numPixels() > 0)
		{
			LEDStrips[i].begin();
			LEDStrips[i].show();
		}
	}

	for (int i = 0; i < TotalSeriesCount; i++)
	{
		LEDStrips[SeriesID[i]].setPixelColor(Series[i], 255, 255, 255);
		LEDStrips[SeriesID[i]].show();
		delay(5);
	}

	Run(LEDStrips, &Split[0], PreviousColor, TotalSeriesCount, Series, SeriesID);
}

void Run(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _TotalSeriesCount, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS])
{
	while (true)
	{
		if (ReadSerial(&_Split[0]))
		{
			switch (_Split[0]) {
			case 'F':
				Mode_F(_LEDStrips, _Split, _PreviousColor, _TotalSeriesCount, _Series, _SeriesID);
				break;
			case 'B':
				Mode_B(_LEDStrips, _Split, _PreviousColor, _TotalSeriesCount, _Series, _SeriesID);
				break;
			case 'W':
				Mode_W(_LEDStrips, _Split, _TotalSeriesCount, _Series, _SeriesID);
				break;
			case 'I':
				Mode_I(_LEDStrips, _Split);
				break;
			case 'S':
				Mode_S(_LEDStrips, _Split, _PreviousColor, _TotalSeriesCount, _Series, _SeriesID);
				break;
			}
		}
	}
}

void Mode_F(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _TotalSeriesCount, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS])
{
	float CurrentColor[3] = { 0,0,0 };
	float CurrentColorJump[3] = { 0,0,0 };

	for (int i = 0; i < 3; i++)
	{
		CurrentColorJump[i] = (((float)_PreviousColor[i] - (float)_Split[i + 1]) * ((float)_Split[5] / (float)100));
		CurrentColor[i] = _PreviousColor[i];
	}

	while ((CurrentColor[0] == _Split[1]) + (CurrentColor[1] == _Split[2]) + (CurrentColor[2] == _Split[3]) < 3)
	{
		for (int i = 0; i < 3; i++)
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
		for (int i = 0; i < _TotalSeriesCount; i++)
		{
			_LEDStrips[_SeriesID[i]].setPixelColor(_Series[i], CurrentColor[0], CurrentColor[1], CurrentColor[2]);
		}
		for (int i = 0; i < LEDStripsS; i++)
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

void Mode_B(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _TotalSeriesCount, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS])
{
	for (int i = 0; i < _TotalSeriesCount; i++)
	{
		_LEDStrips[_SeriesID[i]].setPixelColor(_Series[i], _PreviousColor[0] * ((float)_Split[1] / (float)100), _PreviousColor[1] * ((float)_Split[2] / (float)100), _PreviousColor[2] * ((float)_Split[3] / (float)100));
	}
	for (int i = 0; i < LEDStripsS; i++)
	{
		if (_LEDStrips[i].numPixels() > 0)
		{
			_LEDStrips[i].show();
		}
	}
}

void Mode_W(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], short _TotalSeriesCount, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS])
{
	for (int i = _TotalSeriesCount; i >= 0; i--)
	{
		if (i == 0)
		{
			_LEDStrips[_SeriesID[i]].setPixelColor(_Series[i], _Split[1], _Split[2], _Split[3]);
		}
		else
		{
			_LEDStrips[_SeriesID[i]].setPixelColor(_Series[i], _LEDStrips[_SeriesID[i - 1]].getPixelColor(_Series[i - 1]));
		}
	}
	for (int i = 0; i < LEDStripsS; i++)
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

void Mode_S(Adafruit_NeoPixel _LEDStrips[LEDStripsS], short _Split[SplitS], uint8_t _PreviousColor[3], short _TotalSeriesCount, short _Series[SeriesS], uint8_t _SeriesID[SeriesidS])
{
	int Count = 2;

	for (int i = 0; i < _TotalSeriesCount; i++)
	{
		_LEDStrips[_SeriesID[i]].setPixelColor(_Series[i], 0, 0, 0);
	}
	for (int i = 0; i < _TotalSeriesCount; i += _Split[1])
	{
		for (int j = 0; j < _Split[Count]; j++)
		{
			_LEDStrips[_SeriesID[i + j]].setPixelColor(_Series[i + j], _PreviousColor[0], _PreviousColor[1], _PreviousColor[2]);
		}
		Count++;
		if (Count > SplitS)
			break;
	}
	for (int i = 0; i < LEDStripsS; i++)
	{
		if (_LEDStrips[i].numPixels() > 0)
		{
			_LEDStrips[i].show();
		}
	}
}

bool ReadSerial(short *_Split)
{
	if (Serial.available() > 0)
	{
		char Input[InputS];
		char InnerSplit[InnersplitS][InnersplitY];

		for (int i = 0; i < InputS; i++)
			Input[i] = 0;
		for (int i = 0; i < SplitS; i++)
			_Split[i] = 0;
		for (int i = 0; i < InnersplitS; i++)
			for (int j = 0; j < InnersplitY; j++)
				InnerSplit[i][j] = 0;

		int Step = 0;

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

		int CurrentPos = 0;
		int CurrentStep = 0;
		for (int i = 0; i < InputS; i++)
		{
			if (Input[i] == ';')
			{
				if (IsDigitsOnly((String)InnerSplit[CurrentPos]))
					_Split[CurrentPos] = ((String)InnerSplit[CurrentPos]).toInt();
				else
					_Split[CurrentPos] = InnerSplit[CurrentPos][0];
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
	for (int i = 0; i < _InputString.length(); i++)
	{
		if (_InputString[i] < '0' || _InputString[i] > '9')
			return false;
	}

	return true;
}

void loop() { }