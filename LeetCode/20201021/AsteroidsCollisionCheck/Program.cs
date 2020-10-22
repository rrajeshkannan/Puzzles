using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsCollisionCheck
{
    // https://leetcode.com/explore/featured/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3502/

    public class Solution
    {
        

        public int[] AsteroidCollision(int[] asteroids)
        {
            var postCollisionAsteroids = new Stack<int>();

            for (var i = asteroids.Length - 1; i >= 0; i--)
            {
                // Hint: say a row of asteroids is stable. What happens when a new asteroid is added on the right?

                int currentAsteroid = asteroids[i];
                var currentAsteroidSurvives = true;

                while(postCollisionAsteroids.Any())
                {
                    var existingAsteroid = postCollisionAsteroids.Peek();

                    var collisionPossible = ((currentAsteroid < 0) && (existingAsteroid > 0)) ||
                        ((currentAsteroid > 0) && (existingAsteroid < 0));

                    if (!collisionPossible)
                    {
                        // 1. both asteroids survive, when they do not collide with each other
                        currentAsteroidSurvives = true;
                        break;
                    }

                    int existingAsteroidSize = Math.Abs(existingAsteroid);
                    int currentAsteroidSize = Math.Abs(currentAsteroid);

                    if (currentAsteroidSize < existingAsteroidSize)
                    {
                        // 2. if current asteroid's size is smaller than existing one, it gets blasted by existing asteroid
                        currentAsteroidSurvives = false;
                        break;
                    }

                    // 3. if current asteroid's size is equal to the existing one, both blast each other
                    // 4. if current asteroid's size is bigger than existing one, it survives and blasts existing one
                    // so, in case of (3) and (4), the existing asteroid blasts
                    postCollisionAsteroids.Pop();

                    if (currentAsteroidSize == existingAsteroidSize)
                    {
                        // 3. if current asteroid's size is equal to the existing one, both blast each other
                        currentAsteroidSurvives = false;
                        break;
                    }

                    // 4. when current asteroid's size is bigger than existing one, it survives and continues moving further
                    // if (checkAsteroidSize > lastAsteroidSize)
                }

                if (currentAsteroidSurvives)
                {
                    // current asteroid survived through all the existing ones
                    postCollisionAsteroids.Push(currentAsteroid);
                }
            }

            return postCollisionAsteroids.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            int[] asteriods1 = new int[] { 5, 10, -5 };

            var postCollisionAsteriods1 = solution.AsteroidCollision(asteriods1); // [5,10]

            int[] asteriods2 = new int[] { 8, -8 };

            var postCollisionAsteriods2 = solution.AsteroidCollision(asteriods2); // []

            int[] asteriods3 = new int[] { 10, 2, -5 };

            var postCollisionAsteriods3 = solution.AsteroidCollision(asteriods3); // [10]

            int[] asteriods4 = new int[] { -2, -1, 1, 2 };

            var postCollisionAsteriods4 = solution.AsteroidCollision(asteriods4); // [-2,-1,1,2] - it is wrongly answered inside the context :(
        }
    }
}
