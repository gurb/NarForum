let totalViewChart;


export function drawTotalViewChart(chartType, dayAnonLogs, dayMemLogs) {
    let ctx = document.getElementById('totalViewChart');

    if (totalViewChart != null && totalViewChart.destroy != null) {
        totalViewChart.destroy();
    }

    if (chartType === "Day") {

        if (dayAnonLogs == null && dayMemLogs == null) {
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
                            dayMemLogs["12AM"] ?? 0,
                            dayMemLogs["01AM"] ?? 0,
                            dayMemLogs["02AM"] ?? 0,
                            dayMemLogs["03AM"] ?? 0,
                            dayMemLogs["04AM"] ?? 0,
                            dayMemLogs["05AM"] ?? 0,
                            dayMemLogs["06AM"] ?? 0,
                            dayMemLogs["07AM"] ?? 0,
                            dayMemLogs["08AM"] ?? 0,
                            dayMemLogs["09AM"] ?? 0,
                            dayMemLogs["10AM"] ?? 0,
                            dayMemLogs["11AM"] ?? 0,
                            dayMemLogs["12PM"] ?? 0,
                            dayMemLogs["01PM"] ?? 0,
                            dayMemLogs["02PM"] ?? 0,
                            dayMemLogs["03PM"] ?? 0,
                            dayMemLogs["04PM"] ?? 0,
                            dayMemLogs["05PM"] ?? 0,
                            dayMemLogs["06PM"] ?? 0,
                            dayMemLogs["07PM"] ?? 0,
                            dayMemLogs["08PM"] ?? 0,
                            dayMemLogs["09PM"] ?? 0,
                            dayMemLogs["10PM"] ?? 0,
                            dayMemLogs["11PM"] ?? 0],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [
                            dayAnonLogs["12AM"] ?? 0,
                            dayAnonLogs["01AM"] ?? 0,
                            dayAnonLogs["02AM"] ?? 0,
                            dayAnonLogs["03AM"] ?? 0,
                            dayAnonLogs["04AM"] ?? 0,
                            dayAnonLogs["05AM"] ?? 0,
                            dayAnonLogs["06AM"] ?? 0,
                            dayAnonLogs["07AM"] ?? 0,
                            dayAnonLogs["08AM"] ?? 0,
                            dayAnonLogs["09AM"] ?? 0,
                            dayAnonLogs["10AM"] ?? 0,
                            dayAnonLogs["11AM"] ?? 0,
                            dayAnonLogs["12PM"] ?? 0,
                            dayAnonLogs["01PM"] ?? 0,
                            dayAnonLogs["02PM"] ?? 0,
                            dayAnonLogs["03PM"] ?? 0,
                            dayAnonLogs["04PM"] ?? 0,
                            dayAnonLogs["05PM"] ?? 0,
                            dayAnonLogs["06PM"] ?? 0,
                            dayAnonLogs["07PM"] ?? 0,
                            dayAnonLogs["08PM"] ?? 0,
                            dayAnonLogs["09PM"] ?? 0,
                            dayAnonLogs["10PM"] ?? 0,
                            dayAnonLogs["11PM"] ?? 0],
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
                        data: [34, 14, 15, 16, 17, 18, 19],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [54, 24, 25, 32, 27, 36, 29],
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
                    }]
                },
                legend: { display: false }
            }
        });
    }
    else if (chartType === "Month") {
        totalViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"],
                datasets: [
                    {
                        label: "Member Users",
                        data: [34, 14, 15, 16, 17, 18, 19, 20, 21, 28, 25, 30, 30, 23, 43, 34, 34, 15, 12, 17, 27, 14, 10, 17, 32, 56, 75, 34, 45, 23],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [54, 24, 25, 32, 27, 36, 29, 40, 41, 56, 35, 60, 40, 36, 53, 34, 44, 56, 22, 59, 37, 34, 20, 32, 32, 56, 34, 78, 45, 100, 20],
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
                    }]
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
                        data: [34, 14, 15, 16, 17, 18, 19, 20, 21, 28, 25, 30],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [54, 24, 25, 32, 27, 36, 29, 40, 41, 56, 35, 60],
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
                    }]
                },
                legend: { display: false }
            }
        });
    }


    
}




