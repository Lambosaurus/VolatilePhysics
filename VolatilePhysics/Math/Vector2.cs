/*
 *  VolatilePhysics - A 2D Physics Library for Networked Games
 *  Copyright (c) 2015-2016 - Alexander Shoulson - http://ashoulson.com
 *
 *  This software is provided 'as-is', without any express or implied
 *  warranty. In no event will the authors be held liable for any damages
 *  arising from the use of this software.
 *  Permission is granted to anyone to use this software for any purpose,
 *  including commercial applications, and to alter it and redistribute it
 *  freely, subject to the following restrictions:
 *  
 *  1. The origin of this software must not be misrepresented; you must not
 *     claim that you wrote the original software. If you use this software
 *     in a product, an acknowledgment in the product documentation would be
 *     appreciated but is not required.
 *  2. Altered source versions must be plainly marked as such, and must not be
 *     misrepresented as being the original software.
 *  3. This notice may not be removed or altered from any source distribution.
*/

#if XNA

using Microsoft.Xna.Framework;

namespace Volatile
{
    public static class Vector2Extention
    {
        public static Vector2 Normalised(this Vector2 v)
        {
            float magnitude = v.Length();
            return new Vector2(v.X / magnitude, v.Y / magnitude);
        }
    }
}

#elif !UNITY
namespace Volatile
{
  public struct Vector2
  {
    public static Vector2 Zero { get { return new Vector2(0.0f, 0.0f); } }

    public static float Dot(Vector2 a, Vector2 b)
    {
      return (a.X * b.X) + (a.Y * b.Y);
    }

    public readonly float X;
    public readonly float Y;

    public float LengthSquared()
    {
      get
      {
        return (this.X * this.X) + (this.Y * this.Y);
      }
    }

    public float magnitude 
    { 
      get 
      {
        return Mathf.Sqrt(this.LengthSquared());
      } 
    }

    public Vector2 Normalised()
    {
      get
      {
        float magnitude = this.magnitude;
        return new Vector2(this.X / magnitude, this.Y / magnitude);
      }
    }

    public Vector2 (float x, float y)
    {
      this.X = x;
      this.Y = y;
    }

    public static Vector2 operator *(Vector2 a, float b)
    {
      return new Vector2(a.X * b, a.Y * b);
    }

    public static Vector2 operator *(float a, Vector2 b)
    {
      return new Vector2(b.X * a, b.Y * a);
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
      return new Vector2(a.X + b.X, a.Y + b.Y);
    }

    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
      return new Vector2(a.X - b.X, a.Y - b.Y);
    }

    public static Vector2 operator -(Vector2 a)
    {
      return new Vector2(-a.X, -a.Y);
    }
  }
}
#endif