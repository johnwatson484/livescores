$('.date-picker').on('click', function () {
  var selected = $(this).data('id')
  setView(selected)
  $(this).addClass('btn-primary')
})

$(function () {
  var selected = $('#today-id').first()

  if (selected == null) {
    selected = $('.date-picker').last()
  }

  setView(selected.data('id'))
  selected.addClass('btn-primary')
})

function setView(selected) {

  if (selected != null) {
    $('.date-picker').each(function () {
      $(this).removeClass('btn-primary')
    })

    $('.fixture-card').each(function () {
      if ($(this).data('id') != selected) {
        $(this).hide()
      }
      else {
        $(this).fadeIn()
      }
    })
  }
}
