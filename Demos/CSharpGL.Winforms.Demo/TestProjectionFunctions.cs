using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms.Demo
{
    class TestProjectionFunctions
    {
        public static void TypicalScene()
        {
            {
                float fovy = 60.0f * (float)Math.PI / 180.0f, aspect = 2.0f, zNear = 0.01f, zFar = 100.0f;
                mat4 perspectiveMatrix = glm.perspective(fovy, aspect, zNear, zFar);
                float newFovy, newAspect, newZNear, newZFar;
                if (perspectiveMatrix.TryParse(out newFovy, out newAspect, out newZNear, out newZFar))
                {
                    if (fovy != newFovy)
                    {
                        if (Math.Abs(fovy - newFovy) > 0.01f)
                        {
                            throw new Exception("perspective error");
                        }
                    }
                    if (aspect != newAspect)
                    {
                        if (Math.Abs(aspect - newAspect) > 0.01f)
                        {
                            throw new Exception("perspective error");
                        }
                    }
                    if (zNear != newZNear)
                    {
                        if (Math.Abs(zNear - newZNear) > 0.01f)
                        {
                            throw new Exception("perspective error");
                        }
                    }
                    if (zFar != newZFar)
                    {
                        if (Math.Abs(zFar - newZFar) > 0.01f)
                        {
                            throw new Exception("perspective error");
                        }
                    }
                }
                else
                {
                    throw new Exception("perspective error");
                }
            }
            {
                float left = -400, right = 400, bottom = -300, top = 300, near = -100, far = 200;
                mat4 orthoMatrix = glm.ortho(left, right, bottom, top, near, far);
                float newLeft, newRight, newBottom, newTop, newNear, newFar;
                if (orthoMatrix.TryParse(out newLeft, out newRight, out newBottom, out newTop, out newNear, out newFar))
                {
                    if (left != newLeft)
                    {
                        if (Math.Abs(left - newLeft) > 0.0001f)
                        {
                            throw new Exception("ortho error");
                        }
                    }
                    if (right != newRight)
                    {
                        if (Math.Abs(right - newRight) > 0.0001f)
                        {
                            throw new Exception("ortho error");
                        }
                    }
                    if (bottom != newBottom)
                    {
                        if (Math.Abs(bottom - newBottom) > 0.0001f)
                        {
                            throw new Exception("ortho error");
                        }
                    }
                    if (top != newTop)
                    {
                        if (Math.Abs(top - newTop) > 0.0001f)
                        {
                            throw new Exception("ortho error");
                        }
                    }
                    if (near != newNear)
                    {
                        if (Math.Abs(near - newNear) > 0.0001f)
                        {
                            throw new Exception("ortho error");
                        }
                    }
                    if (far != newFar)
                    {
                        if (Math.Abs(far - newFar) > 0.0001f)
                        {
                            throw new Exception("ortho error");
                        }
                    }
                }
                else
                {
                    throw new Exception("ortho error");
                }
            }
        }
    }
}
