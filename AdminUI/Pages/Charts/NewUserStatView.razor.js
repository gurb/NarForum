let newUserStatViewChart;

export function drawNewUserStatViewChart(chartType, logs) {
    let ctx = document.getElementById('newUserStatViewChart');


    if (newUserStatViewChart != null && newUserStatViewChart.destroy != null) {
        newUserStatViewChart.destroy();
    }

    if (chartType === "Day") {

        if (logs == null) {
            return;
        }
        newUserStatViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["12AM", "01AM", "02AM", "03AM", "04AM", "05AM", "06AM", "07AM", "08AM", "09AM", "10AM", "11AM", "12PM", "01PM", "02PM", "03PM", "04PM", "05PM", "06PM", "07PM", "08PM", "09PM", "10PM", "11PM"],
                datasets: [
                    {
                        label: "New Users",
                        data: [
                            logs["12AM"] ?? 0,
                            logs["01AM"] ?? 0,
                            logs["02AM"] ?? 0,
                            logs["03AM"] ?? 0,
                            logs["04AM"] ?? 0,
                            logs["05AM"] ?? 0,
                            logs["06AM"] ?? 0,
                            logs["07AM"] ?? 0,
                            logs["08AM"] ?? 0,
                            logs["09AM"] ?? 0,
                            logs["10AM"] ?? 0,
                            logs["11AM"] ?? 0,
                            logs["12PM"] ?? 0,
                            logs["01PM"] ?? 0,
                            logs["02PM"] ?? 0,
                            logs["03PM"] ?? 0,
                            logs["04PM"] ?? 0,
                            logs["05PM"] ?? 0,
                            logs["06PM"] ?? 0,
                            logs["07PM"] ?? 0,
                            logs["08PM"] ?? 0,
                            logs["09PM"] ?? 0,
                            logs["10PM"] ?? 0,
                            logs["11PM"] ?? 0
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
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
        newUserStatViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
                datasets: [
                    {
                        label: "New Users",
                        data: [
                            logs["Mon"] ?? 0,
                            logs["Tue"] ?? 0,
                            logs["Wed"] ?? 0,
                            logs["Thu"] ?? 0,
                            logs["Fri"] ?? 0,
                            logs["Sat"] ?? 0,
                            logs["Sun"] ?? 0
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    
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
        newUserStatViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"],
                datasets: [
                    {
                        label: "New Users",
                        data: [
                            logs["01"] ?? 0,
                            logs["02"] ?? 0,
                            logs["03"] ?? 0,
                            logs["04"] ?? 0,
                            logs["05"] ?? 0,
                            logs["06"] ?? 0,
                            logs["07"] ?? 0,
                            logs["08"] ?? 0,
                            logs["09"] ?? 0,
                            logs["10"] ?? 0,
                            logs["11"] ?? 0,
                            logs["12"] ?? 0,
                            logs["13"] ?? 0,
                            logs["14"] ?? 0,
                            logs["15"] ?? 0,
                            logs["16"] ?? 0,
                            logs["17"] ?? 0,
                            logs["18"] ?? 0,
                            logs["19"] ?? 0,
                            logs["20"] ?? 0,
                            logs["21"] ?? 0,
                            logs["22"] ?? 0,
                            logs["23"] ?? 0,
                            logs["24"] ?? 0,
                            logs["25"] ?? 0,
                            logs["26"] ?? 0,
                            logs["27"] ?? 0,
                            logs["28"] ?? 0,
                            logs["29"] ?? 0,
                            logs["30"] ?? 0,
                            logs["31"] ?? 0,
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
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
        newUserStatViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                datasets: [
                    {
                        label: "New Users",
                        data: [
                            logs["Jan"] ?? 0,
                            logs["Feb"] ?? 0,
                            logs["Mar"] ?? 0,
                            logs["Apr"] ?? 0,
                            logs["May"] ?? 0,
                            logs["Jun"] ?? 0,
                            logs["Jul"] ?? 0,
                            logs["Aug"] ?? 0,
                            logs["Sep"] ?? 0,
                            logs["Oct"] ?? 0,
                            logs["Nov"] ?? 0,
                            logs["Dec"] ?? 0,
                        ],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
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
