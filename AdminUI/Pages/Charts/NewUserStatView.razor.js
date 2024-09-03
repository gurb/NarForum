export function drawNewUserStatViewChart() {
    let ctx = document.getElementById('newUserStatViewChart');

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: ["0s", "10s", "20s", "30s", "40s", "50s", "60s"],
            datasets: [
                {
                    label: "Car A - Speed (mph)",
                    data: [0, 59, 75, 20, 20, 55, 40],
                    lineTension: 0,
                    fill: true,
                    borderColor: 'red'
                },
                {
                    label: "Car B - Speed (mph)",
                    data: [20, 15, 60, 60, 65, 30, 70],
                    lineTension: 0,
                    fill: true,
                    borderColor: 'blue'
                }
            ]
        },
        options: {
            legend: { display: false }
        }
    });
}
