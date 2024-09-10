let totalViewChart;


export function drawTotalViewChart(chartType, anonLogs, memLogs) {
    let ctx = document.getElementById('totalViewChart');

    if (totalViewChart != null && totalViewChart.destroy != null) {
        totalViewChart.destroy();
    }
    console.log(anonLogs);

    if (chartType === "Day") {

        if (anonLogs == null && memLogs == null) {
            return;
        }
        totalViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["12AM", "01AM", "02AM", "03AM", "04AM", "05AM", "06AM", "07AM", "08AM", "09AM", "10AM", "11AM", "12PM", "01PM", "02PM", "03PM", "04PM", "05PM", "06PM", "07PM", "08PM", "09PM", "10PM", "11PM"],
                datasets: [
                    {
                        label: "Member Users",
                        data: [
                            memLogs["12AM"] ?? 0,
                            memLogs["01AM"] ?? 0,
                            memLogs["02AM"] ?? 0,
                            memLogs["03AM"] ?? 0,
                            memLogs["04AM"] ?? 0,
                            memLogs["05AM"] ?? 0,
                            memLogs["06AM"] ?? 0,
                            memLogs["07AM"] ?? 0,
                            memLogs["08AM"] ?? 0,
                            memLogs["09AM"] ?? 0,
                            memLogs["10AM"] ?? 0,
                            memLogs["11AM"] ?? 0,
                            memLogs["12PM"] ?? 0,
                            memLogs["01PM"] ?? 0,
                            memLogs["02PM"] ?? 0,
                            memLogs["03PM"] ?? 0,
                            memLogs["04PM"] ?? 0,
                            memLogs["05PM"] ?? 0,
                            memLogs["06PM"] ?? 0,
                            memLogs["07PM"] ?? 0,
                            memLogs["08PM"] ?? 0,
                            memLogs["09PM"] ?? 0,
                            memLogs["10PM"] ?? 0,
                            memLogs["11PM"] ?? 0
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [
                            anonLogs["12AM"] ?? 0,
                            anonLogs["01AM"] ?? 0,
                            anonLogs["02AM"] ?? 0,
                            anonLogs["03AM"] ?? 0,
                            anonLogs["04AM"] ?? 0,
                            anonLogs["05AM"] ?? 0,
                            anonLogs["06AM"] ?? 0,
                            anonLogs["07AM"] ?? 0,
                            anonLogs["08AM"] ?? 0,
                            anonLogs["09AM"] ?? 0,
                            anonLogs["10AM"] ?? 0,
                            anonLogs["11AM"] ?? 0,
                            anonLogs["12PM"] ?? 0,
                            anonLogs["01PM"] ?? 0,
                            anonLogs["02PM"] ?? 0,
                            anonLogs["03PM"] ?? 0,
                            anonLogs["04PM"] ?? 0,
                            anonLogs["05PM"] ?? 0,
                            anonLogs["06PM"] ?? 0,
                            anonLogs["07PM"] ?? 0,
                            anonLogs["08PM"] ?? 0,
                            anonLogs["09PM"] ?? 0,
                            anonLogs["10PM"] ?? 0,
                            anonLogs["11PM"] ?? 0
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#B0C4DE'
                    }
                ]
            },
            options: {
                scales: {
                    xAxes: [{
                        ticks: {
                            maxTicksLimit: 5
                        }
                    }],
                    y: {
                        suggestedMin: 0,
                        ticks: {
                            precision: 0
                        }
                    }
                },
                legend: { display: false }
            }
        });
    }
    else if (chartType === "Week") {
        totalViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
                datasets: [
                    {
                        label: "Member Users",
                        data: [
                            memLogs["Mon"] ?? 0,
                            memLogs["Tue"] ?? 0,
                            memLogs["Wed"] ?? 0,
                            memLogs["Thu"] ?? 0,
                            memLogs["Fri"] ?? 0,
                            memLogs["Sat"] ?? 0,
                            memLogs["Sun"] ?? 0
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [
                            anonLogs["Mon"] ?? 0,
                            anonLogs["Tue"] ?? 0,
                            anonLogs["Wed"] ?? 0,
                            anonLogs["Thu"] ?? 0,
                            anonLogs["Fri"] ?? 0,
                            anonLogs["Sat"] ?? 0,
                            anonLogs["Sun"] ?? 0
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#B0C4DE'
                    }
                ]
            },
            options: {
                scales: {
                    xAxes: [{
                        ticks: {
                            maxTicksLimit: 5
                        }
                    }],
                    y: {
                        suggestedMin: 0,
                        ticks: {
                            precision: 0
                        }
                    }
                },
                legend: { display: false }
            }
        });
    }
    else if (chartType === "Month") {
        totalViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"],
                datasets: [
                    {
                        label: "Member Users",
                        data: [
                            memLogs["01"] ?? 0,
                            memLogs["02"] ?? 0,
                            memLogs["03"] ?? 0,
                            memLogs["04"] ?? 0,
                            memLogs["05"] ?? 0,
                            memLogs["06"] ?? 0,
                            memLogs["07"] ?? 0,
                            memLogs["08"] ?? 0,
                            memLogs["09"] ?? 0,
                            memLogs["10"] ?? 0,
                            memLogs["11"] ?? 0,
                            memLogs["12"] ?? 0,
                            memLogs["13"] ?? 0,
                            memLogs["14"] ?? 0,
                            memLogs["15"] ?? 0,
                            memLogs["16"] ?? 0,
                            memLogs["17"] ?? 0,
                            memLogs["18"] ?? 0,
                            memLogs["19"] ?? 0,
                            memLogs["20"] ?? 0,
                            memLogs["21"] ?? 0,
                            memLogs["22"] ?? 0,
                            memLogs["23"] ?? 0,
                            memLogs["24"] ?? 0,
                            memLogs["25"] ?? 0,
                            memLogs["26"] ?? 0,
                            memLogs["27"] ?? 0,
                            memLogs["28"] ?? 0,
                            memLogs["29"] ?? 0,
                            memLogs["30"] ?? 0,
                            memLogs["31"] ?? 0,
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [
                            anonLogs["01"] ?? 0,
                            anonLogs["02"] ?? 0,
                            anonLogs["03"] ?? 0,
                            anonLogs["04"] ?? 0,
                            anonLogs["05"] ?? 0,
                            anonLogs["06"] ?? 0,
                            anonLogs["07"] ?? 0,
                            anonLogs["08"] ?? 0,
                            anonLogs["09"] ?? 0,
                            anonLogs["10"] ?? 0,
                            anonLogs["11"] ?? 0,
                            anonLogs["12"] ?? 0,
                            anonLogs["13"] ?? 0,
                            anonLogs["14"] ?? 0,
                            anonLogs["15"] ?? 0,
                            anonLogs["16"] ?? 0,
                            anonLogs["17"] ?? 0,
                            anonLogs["18"] ?? 0,
                            anonLogs["19"] ?? 0,
                            anonLogs["20"] ?? 0,
                            anonLogs["21"] ?? 0,
                            anonLogs["22"] ?? 0,
                            anonLogs["23"] ?? 0,
                            anonLogs["24"] ?? 0,
                            anonLogs["25"] ?? 0,
                            anonLogs["26"] ?? 0,
                            anonLogs["27"] ?? 0,
                            anonLogs["28"] ?? 0,
                            anonLogs["29"] ?? 0,
                            anonLogs["30"] ?? 0,
                            anonLogs["31"] ?? 0,
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#B0C4DE'
                    }
                ]
            },
            options: {
                scales: {
                    xAxes: [{
                        ticks: {
                            maxTicksLimit: 5
                        }
                    }],
                    y: {
                        suggestedMin: 0,
                        ticks: {
                            precision: 0
                        }
                    }
                },
                legend: { display: false }
            }
        });
    }
    else if (chartType === "Year") {
        totalViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                datasets: [
                    {
                        label: "Member Users",
                        data: [
                            memLogs["Jan"] ?? 0,
                            memLogs["Feb"] ?? 0,
                            memLogs["Mar"] ?? 0,
                            memLogs["Apr"] ?? 0,
                            memLogs["May"] ?? 0,
                            memLogs["Jun"] ?? 0,
                            memLogs["Jul"] ?? 0,
                            memLogs["Aug"] ?? 0,
                            memLogs["Sep"] ?? 0,
                            memLogs["Oct"] ?? 0,
                            memLogs["Nov"] ?? 0,
                            memLogs["Dec"] ?? 0,
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [
                            anonLogs["Jan"] ?? 0,
                            anonLogs["Feb"] ?? 0,
                            anonLogs["Mar"] ?? 0,
                            anonLogs["Apr"] ?? 0,
                            anonLogs["May"] ?? 0,
                            anonLogs["Jun"] ?? 0,
                            anonLogs["Jul"] ?? 0,
                            anonLogs["Aug"] ?? 0,
                            anonLogs["Sep"] ?? 0,
                            anonLogs["Oct"] ?? 0,
                            anonLogs["Nov"] ?? 0,
                            anonLogs["Dec"] ?? 0,
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#B0C4DE'
                    }
                ]
            },
            options: {
                scales: {
                    xAxes: [{
                        ticks: {
                            maxTicksLimit: 5
                        }
                    }],
                    y: {
                        suggestedMin: 0,
                        ticks: {
                            precision: 0
                        }
                    }
                },
                legend: { display: false }
            }
        });
    }


    
}




