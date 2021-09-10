(function($){
  $(function(){

    $('.sidenav').sidenav();
    $('.parallax').parallax();
      $('.collapsible-accordion').collapsible();
      document.addEventListener('DOMContentLoaded', function () {
          var elems = document.querySelectorAll('.collapsible');
          var instances = M.Collapsible.init(elems, options);
      });
  }); // end of document ready
})(jQuery); // end of jQuery name space


// Or with jQuery

