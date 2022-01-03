function Tempo() {
    
    const conteudo = (
        <div>
            <p>Estamos na seguinte hora: {new Date().toLocaleTimeString()}</p>
        </div>
    )

    ReactDOM.render(conteudo,root)
}

const root = document.getElementById('root')

root.style.textAlign = "center"

root.style.marginTop = "10px"



setInterval(Tempo, 1000)