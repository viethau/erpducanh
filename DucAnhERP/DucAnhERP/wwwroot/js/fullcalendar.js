//window.initFullCalendar = (events) => {
//    console.log("Dữ liệu sự kiện nhận từ Blazor:", events); // Kiểm tra log

//    var calendarEl = document.getElementById('calendar');
//    var calendar = new FullCalendar.Calendar(calendarEl, {
//        initialView: 'dayGridMonth',
//        events: events.map(event => ({
//            title: event.title,
//            start: event.start,
//            end: event.end
//        })),
//        dateClick: function (info) {
//            alert("Bạn đã chọn ngày: " + info.dateStr);
//        }
//    });

//    calendar.render();
//};
