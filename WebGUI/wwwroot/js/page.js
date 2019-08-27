/*$(document).ready(function(){
*/

// JAVASCRIPT SCRIPT 
var swiper = new Swiper('.swiper-container', {
  effect: 'coverflow',
  grabCursor: true,
  centeredSlides: true,
  slidesPerView: 'auto',
  coverflowEffect: {
    rotate: 5,
    stretch: 0,
    depth: 40,
    modifier: 4,
    slideShadows : false,
  },
  pagination: {
    el: '.swiper-pagination',
  },
});

// JQUERY  script 
$(document).ready(function() {

  //this is script acordion 

  $('.catch .acordion h3').click(function(){
    $(this).next().slideToggle();
  });



  // THIS IS LAODING WEBSITE 
  var counter = 0;
  var c = 0;
  var i = setInterval(function(){
      $(".loading-page .counter h1").html(c + "%");
       $(".loading-page .counter .hr").css("width", c + "%");
   //$(".loading-page .counter").css("background", "linear-gradient(to right, #f60d54 "+ c + "%,#0d0d0d "+ c + "%)");

    
   // $(".loading-page .counter h1.color").css("width", c + "%");
   // counter 
    counter++;
    c++;
      
    if(counter == 101) {
        clearInterval(i);
               $('.loading-page').fadeOut(1000);
    }
  }, 50);
    


});
