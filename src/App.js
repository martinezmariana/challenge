import ListaProductos from './components/productos/ListaProductos';

import './App.css';
import { getProductostock } from './apis';
import { useState, useEffect } from 'react';






function App() {
  const [productostockData, setProductostockData] = useState([]);
  
  

  

  useEffect(() => {
    const fetchData = async () => {
      try {
        const productostock = await getProductostock();
        setProductostockData(productostock || []);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="App">
      <div className="row"> 
      
      <div className='row'>

      <ListaProductos productostockData={productostockData} />
      </div>

     
     
    </div>

      
    </div>
    
  );
}

export default App;
