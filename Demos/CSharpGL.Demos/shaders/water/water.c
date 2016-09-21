static GLfloat g_projectionMatrix[16];

static GLfloat g_viewMatrix[16];

static GLfloat g_inverseViewNormalMatrix[9];

//

static GLUSprogram g_program;

static GLint g_projectionMatrixLocation;

static GLint g_viewMatrixLocation;

static GLint g_inverseViewNormalMatrixLocation;

static GLint g_waterPlaneLengthLocation;

static GLint g_passedTimeLocation;

static GLint g_waveParametersLocation;

static GLint g_waveDirectionsLocation;

static GLint g_vertexLocation;

static GLint g_cubemapLocation;

static GLint g_waterTextureLocation;

//

static GLuint g_vao;

static GLuint g_verticesVBO;

static GLuint g_indicesVBO;

//

static GLuint g_cubemap;

GLUSboolean init(GLUSvoid)
{
	GLUStgaimage image;

	GLuint waterTexture;

	g_projectionMatrixLocation = glGetUniformLocation(g_program.program, "u_projectionMatrix");
	g_viewMatrixLocation = glGetUniformLocation(g_program.program, "u_viewMatrix");
	g_inverseViewNormalMatrixLocation = glGetUniformLocation(g_program.program, "u_inverseViewNormalMatrix");

	g_waterPlaneLengthLocation = glGetUniformLocation(g_program.program, "u_waterPlaneLength");

	g_cubemapLocation = glGetUniformLocation(g_program.program, "u_cubemap");

	g_waterTextureLocation = glGetUniformLocation(g_program.program, "u_waterTexture");

	g_passedTimeLocation = glGetUniformLocation(g_program.program, "u_passedTime");

	g_waveParametersLocation = glGetUniformLocation(g_program.program, "u_waveParameters");
	g_waveDirectionsLocation = glGetUniformLocation(g_program.program, "u_waveDirections");

	g_vertexLocation = glGetAttribLocation(g_program.program, "a_vertex");

	//

	waterTexture = initWaterTexture((GLUSfloat)WATER_PLANE_LENGTH);

	glUseProgram(g_program.program);

	glUniform1f(g_waterPlaneLengthLocation, (GLUSfloat)WATER_PLANE_LENGTH);

	glActiveTexture(GL_TEXTURE0);
	glBindTexture(GL_TEXTURE_CUBE_MAP, g_cubemap);
	glUniform1i(g_cubemapLocation, 0);

	glActiveTexture(GL_TEXTURE1);
	glBindTexture(GL_TEXTURE_2D, waterTexture);
	glUniform1i(g_waterTextureLocation, 1);

	glGenVertexArrays(1, &g_vao);
	glBindVertexArray(g_vao);

	glBindBuffer(GL_ARRAY_BUFFER, g_verticesVBO);
	glVertexAttribPointer(g_vertexLocation, 4, GL_FLOAT, GL_FALSE, 0, 0);
	glEnableVertexAttribArray(g_vertexLocation);

	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, g_indicesVBO);

	//

	initBackground();

	//

	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

	glClearDepth(1.0f);

	glEnable(GL_DEPTH_TEST);

	glEnable(GL_CULL_FACE);

	return GLUS_TRUE;
}

GLUSvoid reshape(GLUSint width, GLUSint height)
{
	glViewport(0, 0, width, height);

	glusMatrix4x4Perspectivef(g_projectionMatrix, 40.0f, (GLfloat)width / (GLfloat)height, 1.0f, 1000.0f);

	reshapeBackground(g_projectionMatrix);

	reshapeWaterTexture(width, height);

	glUseProgram(g_program.program);

	glUniformMatrix4fv(g_projectionMatrixLocation, 1, GL_FALSE, g_projectionMatrix);
}

GLUSvoid renderWater(GLUSfloat passedTime)
{
	static WaveParameters waveParameters[NUMBERWAVES];
	static WaveDirections waveDirections[NUMBERWAVES];

	static GLfloat overallSteepness = 0.2f;

	memset(waveParameters, 0, sizeof(waveParameters));
	memset(waveDirections, 0, sizeof(waveDirections));

	// Waves can be faded in and out.

	// Wave One
	waveParameters[0].speed = 1.0f;
	waveParameters[0].amplitude = 0.01f;
	waveParameters[0].wavelength = 4.0f;
	waveParameters[0].steepness = overallSteepness / (waveParameters[0].wavelength * waveParameters[0].amplitude * (GLfloat)NUMBERWAVES);
	waveDirections[0].x = +1.0f;
	waveDirections[0].z = +1.0f;

	// Wave Two
	waveParameters[1].speed = 0.5f;
	waveParameters[1].amplitude = 0.02f;
	waveParameters[1].wavelength = 3.0f;
	waveParameters[1].steepness = overallSteepness / (waveParameters[1].wavelength * waveParameters[1].amplitude * (GLfloat)NUMBERWAVES);
	waveDirections[1].x = +1.0f;
	waveDirections[1].z = +0.0f;

	// Wave Three
	waveParameters[2].speed = 0.1f;
	waveParameters[2].amplitude = 0.015f;
	waveParameters[2].wavelength = 2.0f;
	waveParameters[2].steepness = overallSteepness / (waveParameters[1].wavelength * waveParameters[1].amplitude * (GLfloat)NUMBERWAVES);
	waveDirections[2].x = -0.1f;
	waveDirections[2].z = -0.2f;

	// Wave Four
	waveParameters[3].speed = 1.1f;
	waveParameters[3].amplitude = 0.008f;
	waveParameters[3].wavelength = 1.0f;
	waveParameters[3].steepness = overallSteepness / (waveParameters[1].wavelength * waveParameters[1].amplitude * (GLfloat)NUMBERWAVES);
	waveDirections[3].x = -0.2f;
	waveDirections[3].z = -0.1f;

	glUseProgram(g_program.program);

	glUniformMatrix4fv(g_viewMatrixLocation, 1, GL_FALSE, g_viewMatrix);
	glUniformMatrix3fv(g_inverseViewNormalMatrixLocation, 1, GL_FALSE, g_inverseViewNormalMatrix);

	glUniform1f(g_passedTimeLocation, passedTime);

	glUniform4fv(g_waveParametersLocation, 4 * NUMBERWAVES, (GLfloat*)waveParameters);
	glUniform2fv(g_waveDirectionsLocation, 2 * NUMBERWAVES, (GLfloat*)waveDirections);

	glBindVertexArray(g_vao);

	glFrontFace(GL_CCW);

	glDrawElements(GL_TRIANGLE_STRIP, WATER_PLANE_LENGTH * (WATER_PLANE_LENGTH - 1) * 2, GL_UNSIGNED_INT, 0);
}

GLUSboolean update(GLUSfloat time)
{
	//static GLfloat passedTime = 0.0f;

	//static GLUSfloat angle = 0.0f;

	GLfloat inverseViewMatrix[16];

	glusMatrix4x4LookAtf(g_viewMatrix, 0.0f, 1.0f, 0.0f, (GLfloat) 0.5f * sinf(angle), 1.0f, -(GLfloat) 0.5f * cosf(angle), 0.0f, 1.0f, 0.0f);

	glusMatrix4x4Copyf(inverseViewMatrix, g_viewMatrix, GLUS_TRUE);
	glusMatrix4x4InverseRigidBodyf(inverseViewMatrix);
	glusMatrix4x4ExtractMatrix3x3f(g_inverseViewNormalMatrix, inverseViewMatrix);

	// Render the background
	renderBackground(g_viewMatrix);

	// Render the water texture
	renderWaterTexture(passedTime);

	// Render the water scene
	renderWater(passedTime);

	return GLUS_TRUE;
}

/**
 * Main entry point.
 */
int main(int argc, char* argv[])
{

	glusWindowSetInitFunc(init);

	glusWindowSetReshapeFunc(reshape);

	glusWindowSetUpdateFunc(update);


	return 0;
}