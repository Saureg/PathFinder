$(function () {
    'use strict'

    $('[data-toggle="offcanvas"]').on('click', function () {
        $('.offcanvas-collapse').toggleClass('open')
    })
})

$(function () {
    $("li").on('click', function () {
      $(this).addClass('active')  
    })
})