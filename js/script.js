const observer = new IntersectionObserver((entries) =>{    
    entries.forEach(entry =>{
        if(entry.isIntersecting){
            entry.target.classList.add('visible');}});},{threshold: 0.1});

const elementsToObserve = document.querySelectorAll('p, a, h2, h3, li, img, article');

elementsToObserve.forEach(element =>{
    observer.observe(element);});