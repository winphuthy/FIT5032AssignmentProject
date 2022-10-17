console.log("userOrderCalendar.js is online!");

function calendarGenerate(){
    $('#calendar').fullCalendar({
        defaultView: 'month',
        businessHours: true,
        header: {
            left: "month,agendaWeek, today",
            center: "title",
            right: "prev, next"
            
        },
        events: ordersInCalendar,
        eventClick: function (event) {
            $("#info").css("display", "block");
            $("#serviceName").text(event.title);
        }
    });
}