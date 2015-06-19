$("#add-answer-form").css('cursor', 'pointer');

$("#add-answer-form").click(function () {
  var countChild = $("#list-questions").children().length;
  $("#list-questions").append('<div class="row" id="field-answer-' + countChild +'">' +
    '<div style="padding-top:5pt;margin-left:180px;">' +
    '<div class="order" style="float:left;padding-left:20px">' +
    (countChild+1) +
    '</div>' +
    '<div style="float:left;padding-left:20px">' +
    '<input class="form-control field-answer" name="answers[' + countChild + '].AnswerText" type="text" value="">' +
    '</div>' +
    '<div id="' + countChild + '"style="float:left;padding-left:20px">' +
    '<input type="checkbox" id="answer-checkbox-' + countChild + '" name="answers[' + countChild + '].IsRight" value="true" >' +
    '</div>' +
    '<div id="' + countChild + '"style="float:left;padding-left:20px">' +
    '<img id="remove-answer-form-'+countChild+'" src="../../Content/cancel.png" alt="Remove" style="width: 18px; height:18px;">' +
    '</div>' +
    '</div>' +
    '</div>'
  );
  $('#remove-answer-form-' + countChild + '').css('cursor', 'pointer');
  
  $('#remove-answer-form-' + countChild + '').click(function (e) {
      var num = e.target.parentElement.id;
      var removeElement = $('#' + 'field-answer-' + num).remove();
      var first = $("#list-questions").children(':first');
      for (var i = 0;  i < $("#list-questions").children().length; i++) {
          var array = first.attr('id').split('-');
          if(array[2] >= num) 
          {
              var newNum = parseInt(array[2]) - 1;
              first.attr('id', 'field-answer-' + newNum);
              first.children(':first').children(':first').text(newNum + 1);
              first.children(':first').children(':first').next().children(':first').attr('name', 'answers[' + newNum + '].AnswerText');
              first.children(':first').children(':first').next().next().attr('id', newNum);
              first.children(':first').children(':first').next().next().children(':first').attr('id', 'remove-answer-form-' + newNum);
          }

          first = first.next();
      }
  });

});





function getParameterByName(name) {
  name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
  var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
      results = regex.exec(location.search);
  return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

$(document).ready(function() {
  $('#testId').attr('value', getParameterByName('testId'));
});

function onCompleteAjax(request, status) {
  $('#results').attr('class', 'alert alert-success');
}