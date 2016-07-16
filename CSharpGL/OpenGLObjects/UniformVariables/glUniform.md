# glUniform

glUniform — specify the value of a uniform variable for the current program object
</div><div class="refsynopsisdiv">

## C Specification
<div class="funcsynopsis"><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform1f(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v0</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform2f(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v0</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v1</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform3f(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v0</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v1</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v2</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform4f(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v0</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v1</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v2</var>, </td></tr><tr><td> </td><td>GLfloat <var class="pdparam">v3</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform1i(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v0</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform2i(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v0</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v1</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform3i(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v0</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v1</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v2</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform4i(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v0</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v1</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v2</var>, </td></tr><tr><td> </td><td>GLint <var class="pdparam">v3</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div></div></div><div class="refsect1"><a id="parameters"></a>

## Parameters
<div class="variablelist"><dl class="variablelist"><dt><span class="term">_`location`_</span></dt><dd>

Specifies the location of the uniform variable
		    to be modified.
</dd><dt><span class="term">
		    _`v0`_,
		    _`v1`_,
		    _`v2`_,
		    _`v3`_
		</span></dt><dd>

Specifies the new values to be used for the
		    specified uniform variable.
</dd></dl></div></div><div class="refsynopsisdiv">

## C Specification
<div class="funcsynopsis"><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform1fv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>const GLfloat *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform2fv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>const GLfloat *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform3fv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>const GLfloat *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform4fv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>const GLfloat *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform1iv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>const GLint *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform2iv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>const GLint *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform3iv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>const GLint *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniform4iv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>const GLint *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div></div></div><div class="refsect1"><a id="parameters2"></a>

## Parameters
<div class="variablelist"><dl class="variablelist"><dt><span class="term">_`location`_</span></dt><dd>

Specifies the location of the uniform value to
		    be modified.
</dd><dt><span class="term">_`count`_</span></dt><dd>

Specifies the number of elements that are to
		    be modified. This should be 1 if the targeted
		    uniform variable is not an array, and 1 or more if it is
		    an array.
</dd><dt><span class="term">_`value`_</span></dt><dd>

Specifies a pointer to an array of
		    _`count`_ values that will be
		    used to update the specified uniform
		    variable.
</dd></dl></div></div><div class="refsynopsisdiv">

## C Specification
<div class="funcsynopsis"><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniformMatrix2fv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>GLboolean <var class="pdparam">transpose</var>, </td></tr><tr><td> </td><td>const GLfloat *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniformMatrix3fv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>GLboolean <var class="pdparam">transpose</var>, </td></tr><tr><td> </td><td>const GLfloat *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div><table border="0" class="funcprototype-table" summary="Function synopsis" style="cellspacing: 0; cellpadding: 0;"><tr><td>`void glUniformMatrix4fv(`</td><td>GLint <var class="pdparam">location</var>, </td></tr><tr><td> </td><td>GLsizei <var class="pdparam">count</var>, </td></tr><tr><td> </td><td>GLboolean <var class="pdparam">transpose</var>, </td></tr><tr><td> </td><td>const GLfloat *<var class="pdparam">value</var>`)`;</td></tr></table><div class="funcprototype-spacer"> </div></div></div><div class="refsect1"><a id="parameters3"></a>

## Parameters
<div class="variablelist"><dl class="variablelist"><dt><span class="term">_`location`_</span></dt><dd>

Specifies the location of the uniform value to
		    be modified.
</dd><dt><span class="term">_`count`_</span></dt><dd>

Specifies the number of matrices that are to
		    be modified. This should be 1 if the targeted
		    uniform variable is not an array of matrices, and 1 or more if it is
		    an array of matrices.
</dd><dt><span class="term">_`transpose`_</span></dt><dd>

Specifies whether to transpose the matrix as
		    the values are loaded into the uniform
		    variable. Must be `GL_FALSE`.
</dd><dt><span class="term">_`value`_</span></dt><dd>

Specifies a pointer to an array of
		    _`count`_ values that will be
		    used to update the specified uniform
		    variable.
</dd></dl></div></div><div class="refsect1"><a id="description"></a>

## Description

`glUniform` modifies the value of a
	uniform variable or a uniform variable array. The location of
	the uniform variable to be modified is specified by
	_`location`_, which should be a value
	returned by
	[glGetUniformLocation(https://www.khronos.org/opengles/sdk/docs/man/xhtml/glGetUniformLocation.xml).
	`glUniform` operates on the program object
	that was made part of current state by calling
	[glUseProgram](https://www.khronos.org/opengles/sdk/docs/man/xhtml/glUseProgram.xml).

The commands `glUniform{1|2|3|4}{f|i}`
	are used to change the value of the uniform variable specified
	by _`location`_ using the values passed as
	arguments. The number specified in the command should match the
	number of components in the data type of the specified uniform
	variable (e.g., `1` for float, int, bool;
	`2` for vec2, ivec2, bvec2, etc.). The suffix
	`f` indicates that floating-point values are
	being passed; the suffix `i` indicates that
	integer values are being passed, and this type should also match
	the data type of the specified uniform variable. The
	`i` variants of this function should be used
	to provide values for uniform variables defined as int, ivec2,
	ivec3, ivec4, or arrays of these. The `f`
	variants should be used to provide values for uniform variables
	of type float, vec2, vec3, vec4, or arrays of these. Either the
	`i` or the `f` variants
	may be used to provide values for uniform variables of type
	bool, bvec2, bvec3, bvec4, or arrays of these. The uniform
	variable will be set to false if the input value is 0 or 0.0f,
	and it will be set to true otherwise.

All active uniform variables defined in a program object
	are initialized to 0 when the program object is linked
	successfully. They retain the values assigned to them by a call
	to `glUniform ` until the next successful
	link operation occurs on the program object, when they are once
	again initialized to 0.

The commands `glUniform{1|2|3|4}{f|i}v`
	can be used to modify a single uniform variable or a uniform
	variable array. These commands pass a count and a pointer to the
	values to be loaded into a uniform variable or a uniform
	variable array. A count of 1 should be used if modifying the
	value of a single uniform variable, and a count of 1 or greater
	can be used to modify an entire array or part of an array. When
	loading <span class="emphasis">_n_</span> elements starting at an arbitrary
	position <span class="emphasis">_m_</span> in a uniform variable array,
	elements <span class="emphasis">_m_</span> + <span class="emphasis">_n_</span> - 1 in
	the array will be replaced with the new values. If
	_`m`_ + _`n`_ - 1 is
	larger than the size of the uniform variable array, values for
	all array elements beyond the end of the array will be ignored.
	The number specified in the name of the command indicates the
	number of components for each element in
	_`value`_, and it should match the number of
	components in the data type of the specified uniform variable
	(e.g., `1` for float, int, bool;
	`2` for vec2, ivec2, bvec2, etc.). The data
	type specified in the name of the command must match the data
	type for the specified uniform variable as described previously
	for `glUniform{1|2|3|4}{f|i}`.

For uniform variable arrays, each element of the array is
	considered to be of the type indicated in the name of the
	command (e.g., `glUniform3f` or
	`glUniform3fv` can be used to load a uniform
	variable array of type vec3). The number of elements of the
	uniform variable array to be modified is specified by
	_`count`_

The commands
	`glUniformMatrix{2|3|4}fv` 
        are used to modify a matrix or an array of matrices. The numbers in the
	command name are interpreted as the dimensionality of the matrix.
	The number `2` indicates a 2 × 2 matrix
	(i.e., 4 values), the number `3` indicates a
	3 × 3 matrix (i.e., 9 values), and the number
	`4` indicates a 4 × 4 matrix (i.e., 16
	values). 
        Each matrix is assumed to be
	supplied in column major order. The _`count`_
	argument indicates the number of matrices to be passed. A count
	of 1 should be used if modifying the value of a single matrix,
	and a count greater than 1 can be used to modify an array of
	matrices.
</div><div class="refsect1"><a id="notes"></a>

## Notes

`glUniform1i` and
	`glUniform1iv` are the only two functions
	that may be used to load uniform variables defined as sampler
	types. Loading samplers with any other function will result in a
	`GL_INVALID_OPERATION` error.

If _`count`_ is greater than 1 and the
	indicated uniform variable is not an array, a
	`GL_INVALID_OPERATION` error is generated and the
	specified uniform variable will remain unchanged.

Other than the preceding exceptions, if the type and size
	of the uniform variable as defined in the shader do not match
	the type and size specified in the name of the command used to
	load its value, a `GL_INVALID_OPERATION` error will
	be generated and the specified uniform variable will remain
	unchanged.

If _`location`_ is a value other than
	-1 and it does not represent a valid uniform variable location
	in the current program object, an error will be generated, and
	no changes will be made to the uniform variable storage of the
	current program object. If _`location`_ is
	equal to -1, the data passed in will be silently ignored and the
	specified uniform variable will not be changed.
</div><div class="refsect1"><a id="errors"></a>

## Errors

`GL_INVALID_OPERATION` is generated if there
	is no current program object.

`GL_INVALID_OPERATION` is generated if the
	size of the uniform variable declared in the shader does not
	match the size indicated by the `glUniform`
	command.

`GL_INVALID_OPERATION` is generated if one of
	the integer variants of this function is used to load a uniform
	variable of type float, vec2, vec3, vec4, or an array of these,
	or if one of the floating-point variants of this function is
	used to load a uniform variable of type int, ivec2, ivec3, or
	ivec4, or an array of these.

`GL_INVALID_OPERATION` is generated if
	_`location`_ is an invalid uniform location
	for the current program object and
	_`location`_ is not equal to -1.

`GL_INVALID_VALUE` is generated if
	_`count`_ is less than 0.

`GL_INVALID_VALUE` is generated if
	_`transpose`_ is not `GL_FALSE`.

`GL_INVALID_OPERATION` is generated if
	_`count`_ is greater than 1 and the indicated
	uniform variable is not an array variable.

`GL_INVALID_OPERATION` is generated if a
	sampler is loaded using a command other than
	`glUniform1i` and
	`glUniform1iv`.
</div><div class="refsect1"><a id="associatedgets"></a>

## Associated Gets

[glGet](https://www.khronos.org/opengles/sdk/docs/man/xhtml/glGet.xml)
	with the argument `GL_CURRENT_PROGRAM`

[glGetActiveUniform](https://www.khronos.org/opengles/sdk/docs/man/xhtml/glGetActiveUniform.xml)
	with the handle of a program object and the index of an active uniform variable

[<span class="citerefentry"><span class="refentrytitle">glGetUniform</span></span>](https://www.khronos.org/opengles/sdk/docs/man/xhtml/glGetUniform.xml)
	with the handle of a program object and the location of a
	uniform variable

[<span class="citerefentry"><span class="refentrytitle">glGetUniformLocation</span></span>](https://www.khronos.org/opengles/sdk/docs/man/xhtml/glGetUniformLocation.xml)
	with the handle of a program object and the name of a uniform
	variable
</div><div class="refsect1"><a id="seealso"></a>

## See Also

[<span class="citerefentry"><span class="refentrytitle">glLinkProgram</span></span>](https://www.khronos.org/opengles/sdk/docs/man/xhtml/glLinkProgram.xml),
	[<span class="citerefentry"><span class="refentrytitle">glUseProgram</span></span>](https://www.khronos.org/opengles/sdk/docs/man/xhtml/glUseProgram.xml)
</div><div class="refsect1"><a id="copyright"></a>

## Copyright

            Copyright © 2003-2005 3Dlabs Inc. Ltd. 
            This material may be distributed subject to the terms and conditions set forth in 
            the Open Publication License, v 1.0, 8 June 1999.
            [http://opencontent.org/openpub/](http://opencontent.org/openpub/).
