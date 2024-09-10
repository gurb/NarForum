let browserViewChart;

export function drawBrowserViewChart(logs) {
    let ctx = document.getElementById('browserViewChart');

    if (browserViewChart != null && browserViewChart.destroy != null) {
        browserViewChart.destroy();
    }
    
    if (logs == null) {
        return;
    }

    browserViewChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: [
                'Chrome',
                'Edge',
                'Firefox',
                'Opera',
                'Safari',
                'Internet Explorer',
                'Samsung Browser',
                'UC Browser',
                'Others'
            ],
            datasets: [{
                label: 'Browser Views',
                data: [
                    logs['Chrome'],
                    logs['Edge'],
                    logs['Firefox'],
                    logs['Opera'],
                    logs['Safari'],
                    logs['Internet Explorer'],
                    logs['Samsung Browser'],
                    logs['UC Browser'],
                    logs['Others']
                ],
                backgroundColor: [
                    '#538fff',
                    '#b431e6',
                    '#ff5b58',
                    '#f7ed65',
                    '#fca207',
                    '#28d2ab',
                    '#f6ccf9',
                    '#268189',
                    '#2d1a77',
                ],
                hoverOffset: 4
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    display: false
                }
            }
        }
    });
}
