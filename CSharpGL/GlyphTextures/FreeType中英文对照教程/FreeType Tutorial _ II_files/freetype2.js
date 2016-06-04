/*!
 * freetype2.js
 *
 * auxiliary JavaScript functions for freetype.org
 *
 * written 2012 by Werner Lemberg
 */

// This code snippet needs `jquery'
// (http://code.jquery.com/jquery-1.8.3.js) and `jquery-resize'
// (http://github.com/cowboy/jquery-resize/raw/master/jquery.ba-resize.js)


// Add a bottom bar if the document length exceeds the window height. 
// Additionally ensure that the TOC background reaches the bottom of the
// window.

function addBottomBar() {
  var columnHeight = $('.colright').height();
  var topBarHeight = $('#top').height();
  var winHeight = $(window).height();

  if (columnHeight + topBarHeight > winHeight) {
    $('#TOC-bottom').css('height', columnHeight);
    /* add bottom bar if it doesn't exist already */
    if ($('#bottom').length == 0) {
      $('body').append('<div class="bar" id="bottom"></div>');
    }
  }
  else {
    $('#TOC-bottom').css('height', winHeight - topBarHeight);
    $('#bottom').remove();
  }
}


// `Slightly' scroll the TOC so that its top moves up to the top of the
// screen if we scroll down.  The function also assures that the bottom of
// the TOC doesn't cover the bottom bar (e.g., if the window height is very
// small).

function adjustTOCPosition() {
  var docHeight = $(document).height();
  var TOCHeight = $('#TOC').height();
  var bottomBarHeight = $('#bottom').height();
  var topBarHeight = $('#top').height();

  var scrollTopPos = $(window).scrollTop();
  var topBarBottomPos = 0 + topBarHeight;
  var bottomBarTopPos = docHeight - bottomBarHeight;

  if (scrollTopPos >= topBarBottomPos) {
    $('#TOC').css('top', 0);
  }
  if (scrollTopPos < topBarBottomPos) {
    $('#TOC').css('top', topBarBottomPos - scrollTopPos);
  }
  if (bottomBarTopPos - scrollTopPos < TOCHeight)
    $('#TOC').css('top', bottomBarTopPos - scrollTopPos - TOCHeight);
}


// Hook functions into loading, resizing, and scrolling events.

$(window).load(function() {
  addBottomBar();
  adjustTOCPosition();

  $(window).scroll(function() {
    adjustTOCPosition();
  });

  $('#TOC-bottom').add(window).resize(function() {
    addBottomBar();
  });
});

/* end of freetype2.js */
