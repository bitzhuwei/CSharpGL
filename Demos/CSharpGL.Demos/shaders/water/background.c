/**
 * OpenGL 3 - Example 15
 *
 * @author  Norbert Nopper norbert@nopper.tv
 *
 * Homepage: http://nopper.tv
 *
 * Copyright Norbert Nopper
 */

#include "GL/glus.h"

#include "globals.h"
#include "renderBackground.h"

static GLUSprogram g_programBackground;

static GLint g_projectionMatrixBackgroundLocation;

static GLint g_modelViewMatrixBackgroundLocation;

static GLint g_vertexBackgroundLocation;

static GLint g_normalBackgroundLocation;

static GLint g_cubemapBackgroundLocation;

//

static GLuint g_vaoBackground;

static GLuint g_verticesBackgroundVBO;

static GLuint g_normalsBackgroundVBO;

static GLuint g_indicesBackgroundVBO;

static GLuint g_numberIndicesBackground;

GLUSboolean initBackground()
{

	return GLUS_TRUE;
}

GLUSvoid reshapeBackground(GLUSfloat projectionMatrix[16])
{
	glUseProgram(g_programBackground.program);

	glUniformMatrix4fv(g_projectionMatrixBackgroundLocation, 1, GL_FALSE, projectionMatrix);
}
