document.addEventListener('DOMContentLoaded', () => {

    const selectMarca = document.querySelector('select[name="marca"]');
    const selectModelo = document.querySelector('select[name="modelo"]');
    const searchForm = document.getElementById('search-form'); 
    const searchResultsContainer = document.getElementById('search-results');
    const noResultsMessage = document.getElementById('no-results');

    async function populateBrands(){
        
        try{
            const response = await fetch('https://desenvolvimento-web-api-loja-veiculos.onrender.com/api/veiculos/marcas');

            if(!response.ok){
                throw new Error(`HTTP error! status: ${response.status}`);}

            const marcas = await response.json();

            marcas.forEach(marca => {
                const option = document.createElement('option');
                option.value = marca;
                option.textContent = marca;
                selectMarca.appendChild(option);});} 
                
        catch(error){
            console.error('Erro ao buscar marcas:', error);}}

    async function populateModels(marca){
        selectModelo.innerHTML = '<option value="">Selecione o Modelo</option>';

        if(!marca){ 
            return;}
        
        try{
            const response = await fetch(`https://desenvolvimento-web-api-loja-veiculos.onrender.com/api/veiculos/modelos/marcas/${encodeURIComponent(marca)}`);

            if(!response.ok){
                throw new Error(`HTTP error! status: ${response.status}`);}

            const modelos = await response.json();

            modelos.forEach(modelo => {
                const option = document.createElement('option');
                option.value = modelo;
                option.textContent = modelo;
                selectModelo.appendChild(option);});} 
                
        catch(error){
            console.error('Erro ao buscar modelos:', error);}}

    function displayVehicles(veiculos){
    searchResultsContainer.innerHTML = ''; 

        if(veiculos.length === 0){ 
            noResultsMessage.style.display = 'block';} 
        
        else{
            noResultsMessage.style.display = 'none'; 

            veiculos.forEach(veiculo => { 
                const article = document.createElement('article'); 
                article.classList.add('article-vehic');

                article.innerHTML = 
                `
                <article class="article-vehic">
                    <div class="vehic-img">
                        <img class="visible" src="${
                        veiculo.categoria.toLowerCase() === 'moto' ? 'img/moto.png' : 
                        veiculo.categoria.toLowerCase().includes('caminhao') || veiculo.categoria?.toLowerCase() === 'caminhão'
                        ? 'img/caminhao.png' : 'img/carro.png'}" alt="veículo">
                    </div>
                    <div class="vehic-type">
                        <p class="visible" style="color: #9c1717;"><strong>${veiculo.marca} ${veiculo.modelo}</strong></p>
                        <p class="visible" style="font-size: 12px"><strong>${veiculo.tipo} - ${veiculo.ano}</strong></p>
                    </div>
                    <div class="vehic-info">
                        <h2 class="visible" style="font-size: 15px; color: grey; font-weight: 400; text-align: center; width: 90%">${veiculo.descricao}</h2>
                        <p class="visible"><strong>R$</strong><span>${veiculo.preco.toLocaleString('pt-BR',{minimumFractionDigits: 2, maximumFractionDigits: 2})}</span></p>
                        <div style="display: flex;">
                            <h3 class="visible" style="font-size: 15px; color: grey; margin-right: 60px;">Placa: ${veiculo.placa}</h3>
                            <h3 class="visible" style="font-size: 15px; color: grey;">Ano: ${veiculo.ano}</h3>
                        </div>
                    </div>
                </article>
                `;
                searchResultsContainer.appendChild(article);});}}

    async function performSearch(marca, modelo){ 
        let apiUrl = `https://desenvolvimento-web-api-loja-veiculos.onrender.com/api/veiculos/buscar?`;

        if(marca){
            apiUrl += `marca=${encodeURIComponent(marca)}&`;}

        if(modelo){
            apiUrl += `modelo=${encodeURIComponent(modelo)}&`;}

        if(apiUrl.endsWith('&')){
            apiUrl = apiUrl.slice(0, -1);}

        try{
            const response = await fetch(apiUrl);

            if(!response.ok){
                throw new Error(`HTTP error! status: ${response.status}`);}

            const vehicles = await response.json();
            console.log('Dados recebidos da API:', vehicles);
            displayVehicles(vehicles);}

        catch(error){
            console.error('Erro ao buscar veículos:', error);
            searchResultsContainer.innerHTML = `<p style="color: red;">Ocorreu um erro ao carregar os veículos.</p>`;
            noResultsMessage.style.display = 'none';}}

    async function loadVehicles(){
        try{
            const response = await fetch('https://desenvolvimento-web-api-loja-veiculos.onrender.com/api/veiculos');

            if(!response.ok){
                throw new Error(`HTTP error! status: ${response.status}`);}

            const allVehicles = await response.json();

            if(window.location.pathname.includes('estoque.html')){
                 displayVehicles(allVehicles);}

            else{
                const initialVehicles = allVehicles.slice(0, 3); 
                displayVehicles(initialVehicles);}}
             
        catch(error){
            console.error('Erro ao carregar veículos iniciais:', error);}}

    populateBrands();
    loadVehicles(); 

    selectMarca.addEventListener('change', (event) => {
        const selectedMarca = event.target.value;
        populateModels(selectedMarca);});

    searchForm.addEventListener('submit', (event) => {
        event.preventDefault(); 

        const selectedMarca = selectMarca.value;
        const selectedModelo = selectModelo.value;

        performSearch(selectedMarca, selectedModelo);});});