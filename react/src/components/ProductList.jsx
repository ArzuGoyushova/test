import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const ProductList = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
      axios.get('https://localhost:7032/api/product')
        .then((response) => {
          setProducts(response.data.items);
        })
        .catch((error) => {
          console.error(error);
        });
    }, []);
  
    return (
      <div>
        <h2>Product List</h2>
        <ul>
          {products.map((product) => (
            <li key={product.id}>
              <Link to={`/products/${product.id}`}>{product.name}</Link>
            </li>
          ))}
        </ul>
      </div>
    );
}

export default ProductList
