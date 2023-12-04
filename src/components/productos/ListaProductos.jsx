import React, { useState, useEffect } from 'react';
import { PostProductostock, getProductostock, getStocks, getTipoProductos } from '../../apis';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter} from 'reactstrap';
import axios from 'axios';

 

function ListaProductos() {
  const [productostockData, setProductostockData] = useState([]);
   //MODAL PRODUCTOS
   const [modalInsertar, setModalInsertar] = useState(false);
   const [productoSelecionado, setProductoSelecionado] = useState ({
     id: '',
     producto: '',
     descripcion: '',
     stock: ''
   })
   const handleChange = (e) => {
    const { name, value } = e.target;
    setProductoSelecionado({
      ...productoSelecionado,
      [name]: value,
    });
    console.log(productoSelecionado);
  };
 
   const abrirCerrarModalInsert= () => {
     setModalInsertar(!modalInsertar);
   }

   
 
   useEffect(() => {
    const getData = async () => {
      try {
        const [productostock, stocks, tipoProductos] = await Promise.all([
          getProductostock(),
          getStocks(),
          getTipoProductos()
        ]);
  
        const mergedData = productostock.map(producto => {
          const tipoProducto = tipoProductos.find(tp => tp.id === producto.idTipoProductos);
          const stock = stocks.find(s => s.idProductos === producto.id);
  
          return {
            ...producto,
            descripcion: tipoProducto ? tipoProducto.descripcion : '',
            cantidad: stock ? stock.cantidad : 0
          };
        });
  
        setProductostockData(mergedData);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };
    getData();
  }, []);
  

  const handleInsert = async () => {
    try {
      await axios.post(PostProductostock, productoSelecionado);
      
      abrirCerrarModalInsert();
    } catch (error) {
      console.error('Error al agregar el producto:', error);
    }
  };


  

  return (
    <div className='row'>
      <div className='col-md-12 d-flex mb-7'>
  <h4 className='mb-6'>Reporte Stock</h4>
  <span style={{ marginLeft: '10px' }}>
    <button className='btn btn-round btn-sm btn-success p-1' onClick={()=>abrirCerrarModalInsert()}>Nuevo</button>
  </span>
</div>

      <div className='col-12 mt-1' style={{ overflowX: 'auto' }}>
        <div className='table-responsive table-wrapper-scroll-y' style={{ display: 'block', overflow: 'auto' }}>
          <table className='table table-striped table-sm tableFixHead  border'>
            <thead>
              <tr>
                <th>ID</th>
                <th>Nombre</th>
                <th>Descripción</th>
                <th>Precio</th>
                <th>Stock</th>
                <th className='text-align: center; width: 130px; min-width: 130px;'>Acciones</th>
              </tr>
            </thead>
            <tbody>
              {productostockData.map(producto => (
                <tr key={producto.id}>
                  <td>{producto.id}</td>
                  <td>{producto.nombre}</td>
                  <td>{producto.descripcion}</td>
                  <td>{producto.precio}</td>
                  <td>{producto.cantidad}</td>
                  <td>
                    <button className='btn btn-round btn-sm btn-primary'>Modificar</button>
                    &nbsp;
                    <button className='btn btn-round btn-sm btn-danger ml-auto' >
                      Eliminar
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      {/* onClick={() => handleDelete(producto.id)} */}
      
     <Modal isOpen={modalInsertar} >
     <ModalHeader >Agregar Nuevo Producto</ModalHeader>
     <ModalBody>
       <div className='form-group'>
         <label>Producto: </label>
         <br />
         <input type='text' className='form' name='producto' value={productoSelecionado.producto} onChange={handleChange} />
         <br />
         <label>Precio: </label>
         <br />
         <input type='text' className='form' name='precio' value={productoSelecionado.precio} onChange={handleChange} />
         <br />
         <label>Descripcion: </label>
         <br />
         <input type='text' className='form' name='descripcion' value={productoSelecionado.descripcion} onChange={handleChange} />
         <br />
         <label>Stock: </label>
         <br />
         <input type='text' className='form' name='stock' value={productoSelecionado.stock} onChange={handleChange} />
       </div>
     </ModalBody>
     <ModalFooter>
       <Button className='bnt btn-primary' onClick={handleInsert}>
         Insertar
       </Button> {' '}
       <Button className='bnt btn-danger'  onClick={()=>abrirCerrarModalInsert()}>
         Cancelar
       </Button>
     </ModalFooter>
   </Modal>
      
     
    </div>
  );
}

export default ListaProductos;

