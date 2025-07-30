using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// It's an internal bag. You can find anything you need for lexical analyzing.
    /// </summary>
    partial class LexicalContext {

        /// <summary>
        /// Cursor向前进一个char，即指向下一个char。
        /// <para>如果越过了最后一个char，则指向EOF。</para>
        /// </summary>
        /// <returns>current char after this move forward</returns>
        /// <exception cref="Exception"></exception>
        public char MoveForward() {
            if (this.EOF) {
                throw new Exception(
                    "Algorithm error: move forward too far away!");
            }

            var cursor = this.cursor;

            char c;
            var sourceCode = this.sourceCode;
            int length = sourceCode.Length;
            int index = cursor.index + 1; // move forward
            if (index < length) {
                cursor.index = index;
                c = sourceCode[index];
                // text file is like : xxx\r\nyyy
                // or like : xxx\nyyy
                // not like : xxx\ryyy
                switch (c) {
                case '\n':
                cursor.line++;
                // 0 for '\n', so that 1 for the first char of next line.
                cursor.column = 0;
                break;
                case '\r': /* nothing need to do. */ break;
                default: cursor.column++; break;
                }
            }
            else { // (cursor >= tokenCount)
                c = '\0'; // char.MinValue
                cursor.index = length;
                cursor.column++;
            }

            this.cursor = cursor;
            return c;
        }

        /// <summary>
        /// Cursor向后退<paramref name="step"/>个char，即指向前<paramref name="step"/>个char。
        /// <para>如果越过了第一个char，则抛出Exception。</para>
        /// </summary>
        /// <param name="step"></param>
        public void MoveBack(int step) {
            if (step == 0) { return; }

            if (step < 0) {
                throw new ArgumentOutOfRangeException(
                    nameof(step), "step should > 0!");
            }
            if (this.cursor.index + 1 < step) {
                throw new ArgumentOutOfRangeException(
                    nameof(step), "move back too far away!");
            }

            bool jumpLine = false;
            var cursor = this.cursor;
            int length = this.sourceCode.Length;
            // move back cursor and reduce line no.
            for (int i = 0; i < step; i++) {
                if (cursor.index < length) {
                    char c = this.sourceCode[cursor.index];
                    switch (c) {
                    case '\n':
                    cursor.line--;
                    jumpLine = true;
                    break;
                    case '\r': /* nothing need to do. */ break;
                    default: break;
                    }
                    cursor.index--;
                }
                else { // as if c is '\0'
                    cursor.index--;
                }
            }
            // recalculate column no.
            if (jumpLine) {
                // we run into previous line.
                cursor.column = 0;
                for (int index2 = cursor.index; index2 >= 0; index2--) {
                    cursor.column++;

                    char c = this.sourceCode[index2];
                    //if (c == '\r' || c == '\n') { break; }
                    if (c == '\n' || c == '\r') { break; }
                }
            }
            else {
                // we are still in the same line.
                cursor.column = cursor.column - step;
            }

            this.cursor = cursor;
        }

    }
}
