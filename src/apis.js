import axios from 'axios';


export const getProductostock = async () => {
  try {
    const response = await axios.get('https://localhost:7148/api/productostock');
    return response.data;
  } catch (error) {
    console.error('Error al obtener datos de productostock:', error);
    return null;
  }
};

export const getStocks = async () => {
  try {
    const response = await axios.get('https://localhost:7148/api/productostock/stocks');
    return response.data;
  } catch (error) {
    console.error('Error al obtener datos de stocks:', error);
    return null;
  }
};

export const getTipoProductos = async () => {
  try {
    const response = await axios.get('https://localhost:7148/api/productostock/tipoproductos');
    return response.data;
  } catch (error) {
    console.error('Error al obtener datos de tipoproductos:', error);
    return null;
  }
};

export const PostProductostock = async () => {
    try {
      const response = await axios.post('https://localhost:7148/api/productostock');
      return response.data;
    } catch (error) {
      console.error('Error al obtener datos de productostock:', error);
      return null;
    }
  };
  
  export const PostStocks = async () => {
    try {
      const response = await axios.post('https://localhost:7148/api/productostock/stocks');
      return response.data;
    } catch (error) {
      console.error('Error al obtener datos de stocks:', error);
      return null;
    }
  };
  
  export const PostTipoProductos = async () => {
    try {
      const response = await axios.post('https://localhost:7148/api/productostock/tipoproductos');
      return response.data;
    } catch (error) {
      console.error('Error al obtener datos de tipoproductos:', error);
      return null;
    }
  };
  
  
  


// const Routes = () => {
  
//   return (
//     <Router>
//       <Switch>
//         <Route exact path="/" render={(props) => <Productos {...props} productostockData={productostockData} />} />
//         <Route path="/stocks" render={(props) => <Stocks {...props} stockData={stockData} />} />
//         <Route path="/tipoproductos" render={(props) => <TipoProductos {...props} />} />
       
//       </Switch>
//     </Router>
//   );
// };

// export default Routes;
