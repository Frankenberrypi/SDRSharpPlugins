using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace SDRSharp.EasyScanner
{
    class Simova
    {
      /*
        Simple Moving Average Class
      */

        ArrayList _buffer;
        int _cnt=0;
        bool _isValid = false;
        float _average = 0;

        public Simova(int NumberOfElements, float InitValue)
        {
            _cnt = 0;
            _isValid = false;
            _buffer = new ArrayList(NumberOfElements);

            for (int i = 0; i < NumberOfElements; i++)
            {
                _buffer.Add(InitValue);
            }
        }
        
        public float Add(float data)
        {
            for (int i = 0; i < _buffer.Count-1; i++)
            {
                float tmp      = (float)_buffer[i+1];
                _buffer[i + 1] = (float)_buffer[0];
                _buffer[0] = tmp;
            }

            _buffer[0] = data;

            if (++_cnt == _buffer.Count)
            {
              _isValid = true;
            }

            _average = CalculateAverage();
            return _average;
        }

        public float Average
        {
            get { return _average; }
        }

        public float Current
        {
            get { return (float)_buffer[0]; }
        }

        public bool IsValid
        {
          get { return _isValid; }
        }
        float CalculateAverage()
        {
            float Result=0;
            for (int i = 0; i < _buffer.Count; i++)
            {
                Result += (float)_buffer[i];
            }
            Result /= _buffer.Count;
            return Result;
        }

        public string BufferToString()
        {
          string res = "";
          for (int i = 0; i < _buffer.Count; i++)
          {
            float x = (float)_buffer[i];
            res += x.ToString() + " ";
          }

          return res;
        }
        public void TestThis()
        {
            Simova Sma = new Simova(5, 0);
          
            Console.WriteLine(Sma.Add(1).ToString());
            Console.WriteLine(Sma.BufferToString());
            Console.WriteLine(Sma.Add(2).ToString());
            Console.WriteLine(Sma.BufferToString());
            Console.WriteLine(Sma.Add(3).ToString());
            Console.WriteLine(Sma.BufferToString());
            Console.WriteLine(Sma.Add(4).ToString());
            Console.WriteLine(Sma.BufferToString());
            Console.WriteLine(Sma.Add(5).ToString());
            Console.WriteLine(Sma.BufferToString());
            Console.WriteLine(Sma.Add(6).ToString());
            Console.WriteLine(Sma.BufferToString());
            Console.WriteLine(Sma.Add(7).ToString());
            Console.WriteLine(Sma.BufferToString());
            

            if (Sma.Add(8) != 6)
            {
              throw new Exception("Simova selftest failed!");
            }
        }
    }

}
