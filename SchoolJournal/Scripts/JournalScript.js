


function showPopUp(visible, content = "") {

    var popup = $("#popupMessageBlock");

    var popupBg = $("#popupMessageBlockBackground");

 
    if (visible === true) {
       
        popup.html(content);
        
        popupBg.css("display", "block");
        popupBg.animate({ opacity: 1 }, 1000);
      
        popup.css("display", "block");
        popup.animate({ opacity: 1 }, 1000);
    
    } else {
 
        popupBg.animate({ opacity: 0 }, 1000);

        popup.animate({ opacity: 0 }, 1000, function () {
       
            popup.html("");
           
            popup.css("display", "none");
            popupBg.css("display", "none");
        });
    }
}


function showAddStudentForm() {
  
    $.post("/School/AddStudent/", function (response) {
      
        if (response.length < 10)
           
            alert("Ошибка подгрузки страницы");
        else
            
            showPopUp(true, response);
    });
}


function showAddColumnForm() {
   
    $.post("/School/AddColumn/", function (response) {
 
        if (response.length < 10)
          
            alert("Ошибка подгрузки страницы");
        else
           
            showPopUp(true, response);
    });
}


var studentIdVal, columnIdVal;



function setValue(studentId, columnId) {

    studentIdVal = studentId;
    columnIdVal = columnId;

    $.post("/School/ShowStudentGradeDialog/", function (response) {

        if (response.length < 10)

            alert("Ошибка подгрузки страницы");
        else

            showPopUp(true, response);
    });
}


function addStudent() {
    
    var studentName = $("#popupStudentName").val();
   
    if (studentName.length > 5) {
        
        $.post("/School/saveStudent/", { fio: studentName }, function (response) {
       
            if (response['resultCode'] === 0) {
              
                showPopUp(false);
               
                location.reload();
            }
         
            else
             
                alert(response['resultText']);
        });
    } else {
        alert("Ошибка! Введённое ФИО слишком короткое!");
    }
}


function addColumn() {
  
    var date = $("#popupColumnDate").val();
   
    var type = $("#popupColumnType").val();
    
    if (date.length > 0) {
       
        $.post("/School/saveColumn/", {
            date: date,
            type: type
        }, function (response) {
          
            if (response['resultCode'] === 0) {
               
                showPopUp(false);
             
                location.reload();
            }
     
            else
              
                alert(response['resultText']);
        });
    } else {
        alert("ОШибка! Введите пожалуйста дату");
    }
}


function addValue() {
   
    var first = $("#popupValueFirst").val();
    var second = $("#popupValueSecond").val();

  
    $.post("/School/SetStudentGrade/", {
        studentId: studentIdVal,
        columnId: columnIdVal,
        first: first,
        second: second
    }, function (response) {
        
        if (response['resultCode'] === 0) {
 
            showPopUp(false);
            
            location.reload();
        }
  
        else

            alert(response['resultText']);
    });
}