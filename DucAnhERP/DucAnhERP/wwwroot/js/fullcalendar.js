

window.initFullCalendar = (events, dotNetHelper) => {
    console.log("Dữ liệu sự kiện nhận từ Blazor:", events);

    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        events: events.map(event => ({
            id: event.id, // Đảm bảo có ID để callback
            title: event.title,
            start: event.start,
            end: event.end,
            color: event.color
        })),
        eventClick: function (info) {
            console.log("Sự kiện được click:", info.event.id);
            dotNetHelper.invokeMethodAsync("EventClicked", info.event.id);
        },
        //dateClick: function (info) {
        //    alert("Bạn đã chọn ngày: " + info.dateStr);
        //}
    });

    calendar.render();
};
