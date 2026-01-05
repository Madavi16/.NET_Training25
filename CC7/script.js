

$(document).ready(function()
{
    $("#btnMultiply").click(function()
    {
        var a=$("#num1").val();
        var b=$("#num2").val();
        $("#calcResult").text("Result: "+(a*b));
    });

    $("#btnDivide").click(function()
    {
        var a=$("#num1").val();
        var b=$("#num2").val();

        if(b==0)
        {
            $("#calcResult").text("Cannot divided by zero");

        }
        else{
            $("#calcResult").text("Result: "+(a/b));
        }
    });


    for(var i=0;i<=15;i++)
    {
        if(i%2===0)
        {
            $("#oddEvenRes").append(i+" is Even<br>");

        }
        else{
            $("#oddEvenRes").append(i+ " is Odd<br>");
        }
    }

    $("#btnClick").click(function()
    {
        console.log("Button Clicked");
        alert("Button was Clicked");
    });

    $("#hideOddRows").click(function()
    {
        $("#myTab tr:odd").hide();
    });

    $("#myDiv > h1").css("background-color","cornflowerblue");

    $("#getItem").click(function()
    {
        var index=$("#indexInput").val();
        var item=$("#techList li").eq(index).text();

        $("#singleElement").text("Selected Element: "+item);
    });

    $("#indexList li").each(function(index)
    {
        $(this).prepend(index+" ");
    });


    $("#inputBox").change(function()
    {
        $("#inputResult").append("<p> Input value is changed -> a new paragraph is append to the Input</p>");
    });


})