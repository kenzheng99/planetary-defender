using System;

namespace _Scripts {
    public class GameScore {
        public int Score;
        public int HighScore;
        public int NumLarge;
        public int NumMedium;
        public int NumSmall;
        public int BulletsFired;
        
        public GameScore() {
            ResetScore();
            HighScore = 0;
        }

        public void CountAsteroid(AsteroidSize size) {
            switch (size) {
                case AsteroidSize.SMALL:
                    NumSmall++;
                    break;
                case AsteroidSize.MEDIUM:
                    NumMedium++;
                    break;
                case AsteroidSize.LARGE:
                    NumLarge++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(size), size, null);
            }
        }

        public void ResetScore() {
            Score = 0;
            NumLarge = 0;
            NumMedium = 0;
            NumSmall = 0;
            BulletsFired = 0;
        }
    }
}