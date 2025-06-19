const observer = new IntersectionObserver((entries) =>{    
    entries.forEach(entry =>{
        if(entry.isIntersecting){
            entry.target.classList.add('visible');}});},{threshold: 0.1});

const elementsToObserve = document.querySelectorAll('p, a, h2, h3, li, img, article');

elementsToObserve.forEach(element =>{
    observer.observe(element);});

document.querySelector('.form-simulator').addEventListener('submit', function(e){
    e.preventDefault();

    const vehiclePrice = parseFloat(document.getElementById('vehicle-price').value.replace(/\D/g, ''));
    const downPayment = parseFloat(document.getElementById('down-payment').value.replace(/\D/g, ''));
    const interestRate = parseFloat(document.getElementById('interest-rate').value.replace(',', '.')) / 100;
    const installments = parseInt(document.getElementById('installments').value);

    const financedAmount = vehiclePrice - downPayment;

    const numerator = interestRate * Math.pow(1 + interestRate, installments);
    const denominator = Math.pow(1 + interestRate, installments) - 1;
    const installmentValue = financedAmount * (numerator / denominator);

    const totalPayable = installmentValue * installments;
    const totalInterest = totalPayable - financedAmount;

    alert(
        `Valor das Parcelas: R$ ${installmentValue.toFixed(2)}\n` +
        `Valor Total do Financiamento (com juros): R$ ${totalPayable.toFixed(2)}\n` +
        `Valor Total de Juros: R$ ${totalInterest.toFixed(2)}\n` +
        `Valor Total do Veículo: R$ ${(downPayment + totalPayable).toFixed(2)}`);});