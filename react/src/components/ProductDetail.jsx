import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

const ProductDetail = () => {
  const { id } = useParams();
  const [product, setProduct] = useState(null);

  useEffect(() => {
    axios.get(`https://localhost:7032/api/product/${id}`)
      .then((response) => {
        setProduct(response.data);
        console.log(response);
      })
      .catch((error) => {
        console.error(error);
      });
  }, [id]); 

  if (!product) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h2>Product Details</h2>
      <ul>
        <li key={product.id}>
          <p>Product name: {product.name}</p>
          <p>Product Price: {product.costPrice}</p>
        </li>
      </ul>
    </div>
  );
};

export default ProductDetail;
