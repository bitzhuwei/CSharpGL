// Global variables
var mouseX = 0;
var mouseY = 0;

// Basic functions required for dynamic logic of the webpage
function PostContent(name)
{   
    // Check if data has been succesfully loaded, if so: change title bar as ajax hash fragment
    var title = $('#content-url').text();
  
    // Refresh syntax highlighting
    // $('pre').each(function(i, e) {hljs.highlightBlock(e)});
  
    // Reset DISQUS
    // if(title == '/dev/')
        // title = '';
    // alert('hoi');
    
    // Zet ads op juiste positie onder content (afhankelijk van hoogte content)
    window.setTimeout(function() {  
        AdPositioning();
     }, 500);
  
    // set API resets after time-out (once content is properly loaded)
    window.setTimeout(function() {  
        MathJax.Hub.Queue(["Typeset",MathJax.Hub]);       
	// if (MathJax.InputJax.TeX.resetEquationNumbers)
	// {
        // 	MathJax.Hub.Queue(["resetEquationNumbers", MathJax.InputJax.TeX]);
	// }
        
        var page_url = title == "" ? "http://www.learnopengl.com/" : "http://www.learnopengl.com/?p=" + title;
        if(typeof DISQUS !== 'undefined') {                                              
            DISQUS.reset({
              reload: true,
              config: function () {  
                this.page.identifier = title;  
                this.page.url = page_url;
              }
            });
            $('#disqus_thread').show();
        }
           // Refresh callbacks on <function> tags
    SetFunctionTagCallbacks();        
    }, 500);
        
 
    // Zet ook de juiste button op 'selected'
    $('#nav li span, #nav li a').removeClass('selected');                
    if(title != '')
    {                    
        $('#nav li[id=\'' + title + '\']').children('span, a').addClass('selected');
    }
    // En open menu waar nodig
    var parents = $('#nav span.selected, #nav a.selected').parents('li').children('span.closed, a.closed');
    var index = 0;
    for(index = parents.length - 1; index >= 0; index--)
    {             
        
        var id = $(parents[index]).attr("id").replace( /^\D+/g, '');
        MenuClick(id, false);
    }         
}

// Loads the proper page after page-load.
function LoadPage()
{
       // alert('hoi');
    // $('#content').html('');
    if(window.location.hash)
    {
     
        var name = window.location.hash.substring(2);
        // name = name.replace(/-/g," ");
        var index = name.indexOf('#'); // Remove any hash fragments from the url (Disquss adds hash fragments for comments, but results in 404 pages)
        if(index >= 0)
            name = name.substring(0, index);
        LoadContent(name, false, false);
    }
    else
        LoadContent("Index", false, false);     
}

// Sets callback pointers for mousehover and mousemove, for function references on function tag.     
function SetFunctionTagCallbacks()
{    
    // Callback that ensures that the div will show when the user hoves over the reference
    $('function').hoverIntent(function(e) 
    {             
        $('div#hover').fadeIn(250)
          .css('top', mouseY + CalculateOffset(e, false))
          .css('left', mouseX + CalculateOffset(e, true))
          .appendTo('body');
      }, function() 
      {
        $('div#hover').hide();
      });

    // Callback to make sure the div stays close to the mouse
    $('function').mousemove(function(e) {
        mouseX = e.pageX;
        mouseY = e.pageY;
        var posX = e.pageX + CalculateOffset(e, true);
        var posY = e.pageY + CalculateOffset(e, false);
        $("div#hover").css('top', posY).css('left', posX);          
    });
      
    // Callback that loads the content via ajax in the div
    $('function').mouseenter(function(e) {
        $('div#hover').hide();
        $('div#hover').html('');
        var postData = "function-id=" + ($(this).attr('id'));
        $.post("/content_load.php", postData, function(data) {
            $('div#hover').html(data);
            MathJax.Hub.Queue(["Typeset",MathJax.Hub]);         
			$('div#hover pre').each(function(i, e) {hljs.highlightBlock(e)});			
        });
    });      
    // Ensures that if the user accidentilly enters the hover div, it's still able to hide it by removing the mouse from this div
    $('div#hover').mouseleave(function(e) {
        $(this).hide();
    });
}

// Alters the InDepth tags to contain the proper javascript 
// function SetInDepthTags()
// {    
    // $('indepth').prepend('<strong class="indepth_header">In depth</strong> ');

    // $('indepth strong.indepth_header').click(function() {
        // $(this).parent().children().not('strong.indepth_header').slideToggle(400);    
    // });
// }

// Calculates the horizontal or vertical offset to accomdate for different window sizes.
// Also ensures that if a location is above a certain treshold it will switch values (so html won't overflow out of the window)
function CalculateOffset(e, isHorizontal)
{
    var tresholdHor = 0.55;
    var tresholdVer = 0.45;
    var moveLeft = 20;
    var moveDown = 10;    
    // Do horizontal offset calculations
    if(isHorizontal)
    {
        var windowWidth = window.innerWidth;
        var horPos = e.pageX / windowWidth;
        if(horPos > tresholdHor)
        {
            var hoverWidth = $('div#hover').width() + 20;
            moveLeft = -hoverWidth;
            return moveLeft;                    
        }
        else
            return moveLeft;
    }
    // Do vertical offset calculations
    if(!isHorizontal)
    {        
        var windowHeight = window.innerHeight;        
        // Offset the actual scrolling position from the pageY variable (gets actual window location instead of page location)
        var mouseY = e.pageY - $(window).scrollTop();
        var vertPos = mouseY / windowHeight;
        // $('div#hover').html(windowHeight + ' ' + mouseY); // Debug
        if(vertPos > tresholdVer)
        {
            var hoverHeight = $('div#hover').height() + 40;
            moveDown = -hoverHeight;            
            return moveDown;
        }
        else
            return moveDown;
    }
}

// Toggles the correct background-image once loaded and also slides the menu
function MenuClick(id, animate)
{
    $('#menu-items-of' + id).stop();
    $('#menu-items-of' + id).slideToggle(animate ? 600 : 0);
    $('#menu-item' + id).toggleClass('open');
    $('#menu-item' + id).toggleClass('closed');   
}

// Saves a content/function/category without exiting/reloading the active edit page.
function SaveAjax(id, saveType, isNew, param1, param2, param3, param4, param5, finishFunc)
{
    var postData = { ajax_save : id,
        type : saveType,
        isNew : isNew,
        param1 : param1,
        param2 : param2,
        param3 : param3,
        param4 : param4,
        param5 : param5
    };
    $.post("data_controller.php", postData, function(data) { finishFunc(data); });
}

function ClickVideo(video)
{
    if($(video).children("video")[0].paused)
        $(video).children("video")[0].play();
    else
       $(video).children("video")[0].pause();
    $(video).toggleClass("paused");
    
}

function getRandomInt(max) {
  return Math.floor(Math.random() * max);
}

function AdPositioning()
{
   var content_height = $('#content').height();

	// always do positioning (even if hidden in case of overruling display ads)
	var ad_offset 			= $('#rightonetenthad').height() / 2;
	ad_offset = -400;
	var one_tenth_pos 		= ((content_height / 10) * 0)  - ad_offset;
	var second_tenth_pos 	= ((content_height / 10) * 1)  - ad_offset;
	var third_tenth_pos 	= ((content_height / 10) * 2)  - ad_offset;
	var fourth_tenth_pos 	= ((content_height / 10) * 3)  - ad_offset;
	var fifth_tenth_pos 	= ((content_height / 10) * 4)  - ad_offset;
	var sixth_tenth_pos 	= ((content_height / 10) * 5)  - ad_offset;
	var seventh_tenth_pos 	= ((content_height / 10) * 6)  - ad_offset;
	var eight_tenth_pos 	= ((content_height / 10) * 7)  - ad_offset;
	var ninth_tenth_pos 	= ((content_height / 10) * 8)  - ad_offset;
	var tenth_tenth_pos 	= ((content_height / 10) * 9) - ad_offset;
		
	$('#rightninthtenthdad').offset({ top: ninth_tenth_pos});       
	$('#rightthreetenthad').offset({ top: third_tenth_pos});
	 $('#rightseventhtenthdad').offset({ top: seventh_tenth_pos});
	$('#leftfourthtenthad').offset({ top: fourth_tenth_pos});
	$('#lefteighttenthad').offset({ top: eight_tenth_pos});
	$('#lefttenthtenthad').offset({ top: tenth_tenth_pos});
	$('#rightonetenthad').offset({ top: one_tenth_pos});
	$('#rightfifthtenthad').offset({ top: fifth_tenth_pos});
	$('#lefttwotenthad').offset({ top: second_tenth_pos});
	$('#leftsixthtenthad').offset({ top: sixth_tenth_pos});

    if(content_height >= 2500) 
    {                     
        $('#rightad_container').height($('#content').height());
        $('#nav').height($('#content').height());
		
        	$('#rightninthtenthdad').show();       
        
		if(content_height >= 5000) 
		{
			
			$('#rightthreetenthad').show();				
			$('#rightseventhtenthdad').show();			
			$('#leftfourthtenthad').show();						
			$('#lefteighttenthad').show();						
			$('#lefttenthtenthad').show();
			
			if(content_height >= 8000)
			{				
				$('#rightonetenthad').show();								
				$('#rightfifthtenthad').show();							
				$('#lefttwotenthad').show();								
				$('#leftsixthtenthad').show();
			}
		}
    	}
	
	// don't show in-content ads in the index page
	/*var title = $('#content-url').text();		
	if (title != "")
	{  
		// place in-content ad tags
		$('#in_content_ad_1').insertAfter($('#content p:nth-of-type(' + (5 + getRandomInt(5)) + ')'));
		//$('#in_content_ad_1').show();

		if(content_height >= 3500) 
		{     
			$('#in_content_ad_2').insertAfter($('#content p:nth-of-type(' + (25 + getRandomInt(10)) + ')'));
			//$('#in_content_ad_2').show();
		}
		if(content_height >= 7000) 
		{
			$('#in_content_ad_3').insertAfter($('#content p:nth-of-type(' + (50 + getRandomInt(10)) + ')'));
			//$('#in_content_ad_3').show();
		}
		
		
		//$('#content:nth-child(3)').after('<!-- place in-content --><div id=\'waldo-tag-12074\'> <script>googletag.cmd.push(function() {googletag.display(\'waldo-tag-12074\'); }); </script></div>');
	}*/
}