$(document).ready(function () {
    $("#btnToggle").click(function () {
        $("#page-wrapper").toggleClass("page-wrapper-margin-50");
        $(".navbar-default .sidebar").toggleClass("sidebar-width-50");
        $("#side-menu .nav-link-text").toggleClass("nav-link-text-display-none");

        $(".nav-second-level").toggleClass("sidebar-sub-ul");
        $(".nav-second-level li").toggleClass("bg-color");
    });
	
 
 $("#btnToggle2").click(function () {
        $("#page-wrapper").toggleClass("page-wrapper-margin-50");
        $(".navbar-default .sidebar").toggleClass("sidebar-width-50");
        $("#side-menu .nav-link-text").toggleClass("nav-link-text-display-none");

        $(".nav-second-level").toggleClass("sidebar-sub-ul");
        $(".nav-second-level li").toggleClass("bg-color");
		$("#btnToggle2").toggleClass("side-margin-left-60");
		
		//sidebar icon change left to right 
		icon = $(this).find("#sidebar-icon");
        
		if(icon.hasClass("fa-arrow-right")){
         icon.addClass("fa-arrow-left").removeClass("fa-arrow-right");
        }else{
         icon.addClass("fa-arrow-right").removeClass("fa-arrow-left");
         }
   });
});