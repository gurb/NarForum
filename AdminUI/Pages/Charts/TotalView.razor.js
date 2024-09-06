let totalViewChart;

export function drawTotalViewChart(chartType) {
    let ctx = document.getElementById('totalViewChart');

    if (totalViewChart != null && totalViewChart.destroy != null) {
        totalViewChart.destroy();
    }

    if (chartType === "Days") {
        totalViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"],
                datasets: [
                    {
                        label: "Member Users",
                        data: [13, 14, 15, 16, 17, 18, 19, 20, 21, 28, 25, 30, 30, 23, 43, 34, 34, 15, 12, 17, 27, 14, 10, 17],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [23, 24, 25, 32, 27, 36, 29, 40, 41, 56, 35, 60, 40, 36, 53, 34, 44, 56, 22, 59, 37, 34, 20, 32],
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
    else if (chartType === "Weeks") {
        totalViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"],
                datasets: [
                    {
                        label: "Member Users",
                        data: [34, 14, 15, 16, 17, 18, 19, 20, 21, 28, 25, 30, 30, 23, 43, 34, 34, 15, 12, 17, 27, 14, 10, 17],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [54, 24, 25, 32, 27, 36, 29, 40, 41, 56, 35, 60, 40, 36, 53, 34, 44, 56, 22, 59, 37, 34, 20, 32],
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
    else if (chartType === "Months") {
        totalViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"],
                datasets: [
                    {
                        label: "Member Users",
                        data: [34, 14, 15, 16, 17, 18, 19, 20, 21, 28, 25, 30, 30, 23, 43, 34, 34, 15, 12, 17, 27, 14, 10, 17],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [54, 24, 25, 32, 27, 36, 29, 40, 41, 56, 35, 60, 40, 36, 53, 34, 44, 56, 22, 59, 37, 34, 20, 32],
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
    else if (chartType === "Years") {
        totalViewChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"],
                datasets: [
                    {
                        label: "Member Users",
                        data: [34, 14, 15, 16, 17, 18, 19, 20, 21, 28, 25, 30, 30, 23, 43, 34, 34, 15, 12, 17, 27, 14, 10, 17],
                        lineTension: 0.4,
                        fill: true,
                        borderColor: '#4682B4'
                    },
                    {
                        label: "Anonymous Users",
                        data: [54, 24, 25, 32, 27, 36, 29, 40, 41, 56, 35, 60, 40, 36, 53, 34, 44, 56, 22, 59, 37, 34, 20, 32],
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




