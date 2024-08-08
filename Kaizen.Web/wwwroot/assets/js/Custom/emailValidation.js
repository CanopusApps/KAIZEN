
var dataFromProfileview = $("#empEmail").data("id");

if (IsEmail(dataFromProfileview)) {
     $("#empEmailError").css("color", "red");
     $("#empEmailError").text("Entered Email is not Valid!");
     isValid = false;
}

$('#MiddleName').on('input', function () {
    let value = $(this).val();
    if (/[^a-zA-Z]/.test(value)) {
        $('#middleNameEditPgError').text('Only letters are allowed.');
    } else {
        $('#middleNameEditPgError').text('');
    }
});

function IsEmail(dataFromProfileview) {
    // var emailTextBox = document.getElementById("empEmail");
    // var email = emailValue.toString();
    const emailRegex = /^([a-zA-Z0-9_\.\-\+])+@@(([a - zA - Z0 - 9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
   
    //     const regex = /^([a-zA-Z0-9_\.\-\+])+\(([a - zA - Z0 - 9\-]) +\.)+([a-zA-Z0-9]{2,4})+$/;        

    // if (email.test(emailRegex)) {
    //    if (email.includes(/^@@$/){
    //        // if (email.includes(/^"gmail.com"$/) {
    //        //     return true;
    //        // }
    //        // else{
    //        //     return
    //        // }
    //    }
    //    return false;
    // } 
    // if (email.test(emailRegex)) {            
    //     if (email.includes("gmail.com") 
    //            return true;
    // }
    // if (!emailRegex.match(emailValue)) {
    //     if (email.includes(/^@@$/ ){
    //         return true;

    // }
    // if (email != "") {
    //     var result = email.match(emailRegex);
    //     if (result[0] != "") {
    //         return true;
    //     }
    // }
    // if (emailValue.match(emailRegex)) {
    //     var res = emailValue.match(emailRegex);
    //     return true;
    // }


    //        return false;
    if (!emailRegex.test(dataFromProfileview)) {
        return false;
    }
    else {
        return true;
    }
}

//@model Email_Validation_MVC_Core.Models.PersonModel
//@addTagHelper*, Microsoft.AspNetCore.Mvc.TagHelpers
//@{
//    Layout = null;
//}
 
//< !DOCTYPE html >

//    <html>
//        <head>
//            <meta name="viewport" content="width=device-width" />
//            <title>Index</title>
//            <style type="text/css">
//                body {font - family: Arial; font-size: 10pt; }
//                .error {color: red; }
//            </style>
//        </head>
//        <body>
//            <form method="post" asp-controller="Home" asp-action="Index">
//                <table>
//                    <tr>
//                        <td><input type="text" asp-for="Email" /></td>
//                        <td><span asp-validation-for="Email" class="error"></span></td>
//                    </tr>
//                    <tr>
//                        <td><input type="submit" value="Submit" /></td>
//                        <td></td>
//                    </tr>
//                </table>
//            </form>

//            <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.js"></script>
//            <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.3/jquery.validate.js"></script>
//            <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.12/jquery.validate.unobtrusive.js"></script>
//        </body>
//    </html>