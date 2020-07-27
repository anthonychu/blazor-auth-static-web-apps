module.exports = async function (context, req) {
    const weather = [];
    const conditions = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
    const now = new Date().getTime();
    for (let i = 0; i < 5; i++) {
        weather.push({
            "date": new Date(now + i * 24 * 60 * 60 * 1000),
            "temperatureC": Math.floor(Math.random() * 75) - 20,
            "summary": conditions[Math.floor(Math.random() * conditions.length)]
        });
    }
    context.res.json(weather);
}