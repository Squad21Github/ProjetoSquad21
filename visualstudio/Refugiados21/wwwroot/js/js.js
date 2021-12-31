function Tempo() {
    // jsx a apresentar
    const conteudo = (
        <div>
            <span>&copy; 2021 - Refugiados1 - <a href="Home/Sobre" asp-area="" asp-controller="Home" asp-action="Sobre">Sobre</a></span>
            <h3>Tempo atual</h3>
            <p>Estamos na seguinte hora: {new Date().toLocaleTimeString()}</p>
        </div>
    )

    ReactDOM.render(conteudo,root)
}

const root = document.getElementById('root')

root.style.textAlign = "center"

root.style.marginTop = "30px"



setInterval(Tempo, 1000)