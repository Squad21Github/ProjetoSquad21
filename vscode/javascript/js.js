function Tempo() {
    // jsx a apresentar
    const conteudo = (
        <div>
            <h3>Tempo atual</h3>
            <p>Estamos na seguinte hora: {new Date().toLocaleTimeString()}</p>/
        </div>
    )
    ReactDOM.render(conteudo,root)
}

const root = document.getElementById('root')

setInterval(Tempo, 1000)