$(document).ready(function(){
$("input[type=password]").keyup(function(){
    if ($("#formPassword").val().length != 0){
        if ($("#formPassword").val() == $("#inputCNew").val()) {
            $("#pwmatch").removeClass("glyphicon-remove");
            $("#pwmatch").addClass("glyphicon-ok");
            $("#pwmatch").css("color","#00A41E");
        }else{
            $("#pwmatch").removeClass("glyphicon-ok");
            $("#pwmatch").addClass("glyphicon-remove");
            $("#pwmatch").css("color","#FF0004");
        }
    }
    else{
        $("#pwmatch").removeClass("glyphicon-ok");
        $("#pwmatch").addClass("glyphicon-remove");
        $("#pwmatch").css("color","#FF0004");
    }
    
});
});