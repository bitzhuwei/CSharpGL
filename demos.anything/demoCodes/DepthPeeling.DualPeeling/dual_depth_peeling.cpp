//--------------------------------------------------------------------------------------
// Order Independent Transparency with Dual Depth Peeling
//
// Author: Louis Bavoil
// Email: sdkfeedback@nvidia.com
//
// Depth peeling is traditionally used to perform order independent transparency (OIT)
// with N geometry passes for N transparency layers. Dual depth peeling enables peeling
// N transparency layers in N/2+1 passes, by peeling from the front and the back
// simultaneously using a min-max depth buffer. This sample performs either normal or
// dual depth peeling and blends on the fly.
//
// Copyright (c) NVIDIA Corporation. All rights reserved.
//--------------------------------------------------------------------------------------
#define FOVY 30.0
#define ZNEAR 0.0001
#define ZFAR 10.0
#define FPS_TIME_WINDOW 1
#define MAX_DEPTH 1.0

int g_numPasses = 4;
int g_imageWidth = 1024;
int g_imageHeight = 768;

GLuint g_quadDisplayList;
GLuint g_vboId;
GLuint g_eboId;

bool g_useOQ = true;
GLuint g_queryId;

GLSLProgramObject initProgram;
GLSLProgramObject peelProgram;
GLSLProgramObject blendProgram;
GLSLProgramObject finalProgram;

float g_opacity = 0.6;
unsigned g_numGeoPasses = 0;

float g_white[3] = { 1.0, 1.0, 1.0 };
float g_black[3] = { 0.0 };
float* g_backgroundColor = g_white;

GLuint backBlenderFBO;
GLuint peelingSingleFBO;
GLuint depthTextures[2];
GLuint frontBlenderTextures[2];
GLuint backTmpTextures[2];
GLuint backBlenderTexture;

GLenum g_drawBuffers[] = { GL_COLOR_ATTACHMENT0,
GL_COLOR_ATTACHMENT1,
GL_COLOR_ATTACHMENT2,
GL_COLOR_ATTACHMENT3,
GL_COLOR_ATTACHMENT4,
GL_COLOR_ATTACHMENT5,
GL_COLOR_ATTACHMENT6
};

//--------------------------------------------------------------------------
void InitDualPeelingRenderTargets()
{
	glGenTextures(2, depthTextures);
	glGenTextures(2, frontBlenderTextures);
	glGenTextures(2, backTmpTextures);
	glGenFramebuffers(1, &peelingSingleFBO);
	for (int i = 0; i < 2; i++)
	{
		glBindTexture(GL_TEXTURE_RECTANGLE, depthTextures[i]);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_WRAP_S, GL_CLAMP);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_WRAP_T, GL_CLAMP);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
		glTexImage2D(GL_TEXTURE_RECTANGLE, 0, GL_FLOAT_RG32_NV, g_imageWidth, g_imageHeight, 0, GL_RGB, GL_FLOAT, 0);

		glBindTexture(GL_TEXTURE_RECTANGLE, frontBlenderTextures[i]);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_WRAP_S, GL_CLAMP);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_WRAP_T, GL_CLAMP);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
		glTexImage2D(GL_TEXTURE_RECTANGLE, 0, GL_RGBA, g_imageWidth, g_imageHeight, 0, GL_RGBA, GL_FLOAT, 0);

		glBindTexture(GL_TEXTURE_RECTANGLE, backTmpTextures[i]);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_WRAP_S, GL_CLAMP);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_WRAP_T, GL_CLAMP);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
		glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
		glTexImage2D(GL_TEXTURE_RECTANGLE, 0, GL_RGBA, g_imageWidth, g_imageHeight, 0, GL_RGBA, GL_FLOAT, 0);
	}

	glGenTextures(1, &backBlenderTexture);
	glBindTexture(GL_TEXTURE_RECTANGLE, backBlenderTexture);
	glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_WRAP_S, GL_CLAMP);
	glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_WRAP_T, GL_CLAMP);
	glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_RECTANGLE, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexImage2D(GL_TEXTURE_RECTANGLE, 0, GL_RGB, g_imageWidth, g_imageHeight, 0, GL_RGB, GL_FLOAT, 0);

	glGenFramebuffers(1, &backBlenderFBO);
	glBindFramebuffer(GL_FRAMEBUFFER, backBlenderFBO);
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, GL_TEXTURE_RECTANGLE, backBlenderTexture, 0);

	glBindFramebuffer(GL_FRAMEBUFFER, peelingSingleFBO);

	int j = 0;
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, GL_TEXTURE_RECTANGLE, depthTextures[j], 0);
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT1, GL_TEXTURE_RECTANGLE, frontBlenderTextures[j], 0);
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT2, GL_TEXTURE_RECTANGLE, backTmpTextures[j], 0);

	j = 1;
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT3, GL_TEXTURE_RECTANGLE, depthTextures[j], 0);
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT4, GL_TEXTURE_RECTANGLE, frontBlenderTextures[j], 0);
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT5, GL_TEXTURE_RECTANGLE, backTmpTextures[j], 0);

	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT6, GL_TEXTURE_RECTANGLE, backBlenderTexture, 0);

	CHECK_GL_ERRORS;
}

//--------------------------------------------------------------------------
void DeleteDualPeelingRenderTargets()
{
	glDeleteFramebuffers(1, &backBlenderFBO);
	glDeleteFramebuffers(1, &peelingSingleFBO);
	glDeleteTextures(2, depthTextures);
	glDeleteTextures(2, frontBlenderTextures);
	glDeleteTextures(2, backTmpTextures);
	glDeleteTextures(1, &backBlenderTexture);
}

//--------------------------------------------------------------------------
void BuildShaders()
{
	printf("\nloading shaders...\n");

	initProgram.attachVertexShader(SHADER_PATH "dual_peeling_init_vertex.glsl");
	initProgram.attachFragmentShader(SHADER_PATH "dual_peeling_init_fragment.glsl");
	initProgram.link();

	peelProgram.attachVertexShader(SHADER_PATH "shade_vertex.glsl");
	peelProgram.attachVertexShader(SHADER_PATH "dual_peeling_peel_vertex.glsl");
	peelProgram.attachFragmentShader(SHADER_PATH "shade_fragment.glsl");
	peelProgram.attachFragmentShader(SHADER_PATH "dual_peeling_peel_fragment.glsl");
	peelProgram.link();

	blendProgram.attachVertexShader(SHADER_PATH "dual_peeling_blend_vertex.glsl");
	blendProgram.attachFragmentShader(SHADER_PATH "dual_peeling_blend_fragment.glsl");
	blendProgram.link();

	finalProgram.attachVertexShader(SHADER_PATH "dual_peeling_final_vertex.glsl");
	finalProgram.attachFragmentShader(SHADER_PATH "dual_peeling_final_fragment.glsl");
	finalProgram.link();

}

//--------------------------------------------------------------------------
void DestroyShaders()
{
	initProgram.destroy();
	peelProgram.destroy();
	blendProgram.destroy();
	finalProgram.destroy();

}

//--------------------------------------------------------------------------
void InitGL()
{
	// Allocate render targets first
	InitDualPeelingRenderTargets();
	glBindFramebuffer(GL_FRAMEBUFFER, 0);

	glGenQueries(1, &g_queryId);
}

//--------------------------------------------------------------------------
void RenderDualPeeling()
{
	glDisable(GL_DEPTH_TEST);
	glEnable(GL_BLEND);

	// ---------------------------------------------------------------------
	// 1. Initialize Min-Max Depth Buffer
	// ---------------------------------------------------------------------

	glBindFramebuffer(GL_FRAMEBUFFER, peelingSingleFBO);

	// Render targets 1 and 2 store the front and back colors
	// Clear to 0.0 and use MAX blending to filter written color
	// At most one front color and one back color can be written every pass
	glDrawBuffers(2, &g_drawBuffers[1]);
	glClearColor(0, 0, 0, 0);
	glClear(GL_COLOR_BUFFER_BIT);

	// Render target 0 stores (-minDepth, maxDepth, alphaMultiplier)
	glDrawBuffer(g_drawBuffers[0]);
	glClearColor(-MAX_DEPTH, -MAX_DEPTH, 0, 0);
	glClear(GL_COLOR_BUFFER_BIT);
	glBlendEquation(GL_MAX);

	initProgram.bind();
	DrawModel();
	initProgram.unbind();

	CHECK_GL_ERRORS;

	// ---------------------------------------------------------------------
	// 2. Dual Depth Peeling + Blending
	// ---------------------------------------------------------------------

	// Since we cannot blend the back colors in the geometry passes,
	// we use another render target to do the alpha blending
	//glBindFramebuffer(GL_FRAMEBUFFER, backBlenderFBO);
	glDrawBuffer(g_drawBuffers[6]);
	glClearColor(g_backgroundColor[0], g_backgroundColor[1], g_backgroundColor[2], 0);
	glClear(GL_COLOR_BUFFER_BIT);

	int currId = 0;

	for (int pass = 1; g_useOQ || pass < g_numPasses; pass++) {
		currId = pass % 2;
		int prevId = 1 - currId;
		int bufId = currId * 3;

		//glBindFramebuffer(GL_FRAMEBUFFER, g_dualPeelingFboId[currId]);

		glDrawBuffers(2, &g_drawBuffers[bufId + 1]);
		glClearColor(0, 0, 0, 0);
		glClear(GL_COLOR_BUFFER_BIT);

		glDrawBuffer(g_drawBuffers[bufId + 0]);
		glClearColor(-MAX_DEPTH, -MAX_DEPTH, 0, 0);
		glClear(GL_COLOR_BUFFER_BIT);

		// Render target 0: RG32F MAX blending
		// Render target 1: RGBA MAX blending
		// Render target 2: RGBA MAX blending
		glDrawBuffers(3, &g_drawBuffers[bufId + 0]);
		glBlendEquation(GL_MAX);

		peelProgram.bind();
		peelProgram.bindTextureRECT("DepthBlenderTex", depthTextures[prevId], 0);
		peelProgram.bindTextureRECT("FrontBlenderTex", frontBlenderTextures[prevId], 1);
		peelProgram.setUniform("Alpha", (float*)&g_opacity, 1);
		DrawModel();
		peelProgram.unbind();

		CHECK_GL_ERRORS;

		// Full screen pass to alpha-blend the back color
		glDrawBuffer(g_drawBuffers[6]);

		glBlendEquation(GL_FUNC_ADD);
		glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

		if (g_useOQ) {
			glBeginQuery(GL_SAMPLES_PASSED, g_queryId);
		}

		blendProgram.bind();
		blendProgram.bindTextureRECT("TempTex", backTmpTextures[currId], 0);
		glCallList(g_quadDisplayList);
		blendProgram.unbind();

		CHECK_GL_ERRORS;

		if (g_useOQ) {
			glEndQuery(GL_SAMPLES_PASSED);
			GLuint sample_count;
			glGetQueryObjectuiv(g_queryId, GL_QUERY_RESULT, &sample_count);
			if (sample_count == 0) {
				break;
			}
		}
	}

	glDisable(GL_BLEND);

	// ---------------------------------------------------------------------
	// 3. Final Pass
	// ---------------------------------------------------------------------

	glBindFramebuffer(GL_FRAMEBUFFER, 0);
	glDrawBuffer(GL_BACK);

	finalProgram.bind();
	finalProgram.bindTextureRECT("DepthBlenderTex", depthTextures[currId], 0);
	finalProgram.bindTextureRECT("FrontBlenderTex", frontBlenderTextures[currId], 1);
	finalProgram.bindTextureRECT("BackBlenderTex", backBlenderTexture, 2);
	glCallList(g_quadDisplayList);
	finalProgram.unbind();

	CHECK_GL_ERRORS;
}

