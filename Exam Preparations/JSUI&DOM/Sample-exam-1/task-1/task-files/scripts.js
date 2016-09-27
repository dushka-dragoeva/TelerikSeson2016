function createCalendar(selector, events) {


    var WEEKS = 5;
    var WEEK_DAYS = ['Sat', 'Sun', 'Mon', 'Tue', 'Wen', 'Thu', 'Fri'];
    var DAYS = 30;

    // don't use directly the collection
    var preparedEvents=prepareEvents(events);
    console.log(preparedEvents);

    var fragment = document.createDocumentFragment();
    var day = document.createElement('div');
    var title = document.createElement('h4');
    var week = document.createElement('div');
    var event = document.createElement('p');

    applyDayStyles();
    applyTitleStyles();
    applyEventStyles();

    var calendar = document.querySelector(selector);

    var month = createMonth();

    calendar.appendChild(month);
   // addEvents();

    // Dictionary
    function prepareEvents(events) {
        var result=[];
        for (var i = 0; i < events.length; i++) {
            var currDate = events[i].date;
            result[currDate]=events[i];
        }

        return result;

    }
    function createMonth() {
        var currentM = document.createElement('div');
        currentM.id = 'month';

        for (i = 0; i < WEEKS; i += 1) {
            var startDate = 7 * i + 1;
            var endDate = startDate + 6;

            var monthWeek = createWeek(startDate, endDate);
            currentM.appendChild(monthWeek);
        }

        var frag = fragment.appendChild(currentM);

        return frag;

    }

    function createWeek(startDay, endDay) {
        var currentWeek = week.cloneNode(true);

        for (var i = startDay; i <= endDay && i <= DAYS; i += 1) {
            var weekDay = creteDay(i);
            currentWeek.appendChild(weekDay);
            //  days.push(weekDay);

        }
        return currentWeek;

    }

    function creteDay(date) {

        var currentDay = day.cloneNode(true);
        var currentDayTitle = createTitle(date);
        currentDay.appendChild(currentDayTitle)
        getCurrentEvent(date,currentDay)  // to change name if repeated
        return currentDay
    }

    function getCurrentEvent(date, dayElement) {
        var currDayEvent=preparedEvents[date];
        if(currDayEvent){
            var calendarEvent=event.cloneNode(true);
            calendarEvent.innerText=currDayEvent.hour + '-' + currDayEvent.duration + '-' + currDayEvent.title;
            dayElement.appendChild(calendarEvent);
        }


    }

    function createTitle(date) {
        var currentTitle = title.cloneNode(true);
        currentTitle.innerText = WEEK_DAYS[date % 7] + ' ' + date + ' ' + 'June 2014';

        return currentTitle;
    }

    function applyDayStyles() {
        day.style.display = 'inline-block';
        day.style.width = '150px';
        day.style.height = '150px';
        day.style.border = '1px solid black';

    }

    function applyTitleStyles() {
        title.style.textAlign = 'center';
        title.style.borderBottom = '1px solid black';
        title.style.margin = '0';
        title.style.backgroundColor = 'lightGray';
    }

    function applyEventStyles() {
        event.style.float = 'left';
    }

    // My Way

    function addEvents() {
        var days = calendar.getElementsByTagName('h4');

        for (i = 0; i < events.length; i += 1) {
            // var currentEvent = events[i];
            var currentEventDate = +events[i].date;
            console.log(currentEventDate);

            var currentEvent = event.cloneNode(true);
            currentEvent.innerText = events[i].hour + '-' + events[i].duration + '-' + events[i].title;
            console.log(currentEvent.innerText);

            var eventDay = days[currentEventDate];
            console.log(eventDay);
            //.parentNode;//appendChild(currentEvent);
            eventDay.parentNode.appendChild(currentEvent);
            console.log(eventDay);
        }
    }

    //  hash table -video Ivo

    calendar.addEventListener('mouseover',function (ev) {
        var target=ev.target;
        if(target.tagName==='H4'){
            target.style.background='gray';
        }

    },false)

    calendar.addEventListener('mouseout',function (ev) {
        var target=ev.target;
        if(target.tagName==='H4'){
            target.style.background='lightgray';
        }

    },false)

    calendar.addEventListener('click',function (ev) {
        var target=ev.target;
        if(target.tagName==='H4'){
            target.style.background='white';
        }

    },false)

    return calendar;
}