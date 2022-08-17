using UnityEngine;

namespace ArkanoidProj
{
    public class EditorGrid
    {
        private const float _leftPosition = -4.87f;
        private const float _upPosition = 7f;
        private const int _columnCount = 10;
        private const int _lineCount = 9;
        private const float _offset = 1.08f;

        public Vector2 CheckPosition(Vector2 position)
        {
            Vector2 tempPos = Vector2.zero;
            float x = _leftPosition - _offset / 2;
            float y = _upPosition + _offset / 2;

            if (position.x > x && position.x < (x + _offset * _columnCount) && position.y < y && position.y > (y - _offset * _lineCount))
            {
                for (int i = 0; i < _columnCount; i++)
                {
                    if (position.x > x && position.x < (x + _offset))
                    {
                        tempPos.x = x + _offset / 2;
                        break;
                    }
                    else
                    {
                        x += _offset;
                    }
                }

                for (int i = 0; i < _lineCount; i++)
                {
                    if (position.y < y && position.y > (y - _offset))
                    {
                        tempPos.y = y - _offset / 2;
                        break;
                    }
                    else
                    {
                        y -= _offset;
                    }
                }
            }
            else
            {
                Debug.LogWarning("Out of the play zone");
            }

            return tempPos;
        }

        
    }
}

