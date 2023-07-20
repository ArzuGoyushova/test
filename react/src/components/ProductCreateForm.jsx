import React, { useState } from 'react';
import axios from 'axios';

const ProductCreateForm = () => {
  const [formData, setFormData] = useState({
    name: '',
    salePrice: '',
    costPrice: '',
    categoryId: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevFormData) => ({ ...prevFormData, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.post('https://localhost:7032/api/product', formData)
      .then((response) => {
        console.log('Product created successfully!');
        // Do any additional actions, such as showing a success message or redirecting.
      })
      .catch((error) => {
        console.error('Error creating product:', error);
        // Handle errors, such as showing an error message to the user.
      });
  };

  return (
    <div>
      <h2>Create Product</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Name:</label>
          <input type="text" name="name" value={formData.name} onChange={handleChange} />
        </div>
        <div>
          <label>Sale Price:</label>
          <input type="number" name="salePrice" value={formData.salePrice} onChange={handleChange} />
        </div>
        <div>
          <label>Cost Price:</label>
          <input type="number" name="costPrice" value={formData.costPrice} onChange={handleChange} />
        </div>
        <div>
          <label>Category ID:</label>
          <input type="number" name="categoryId" value={formData.categoryId} onChange={handleChange} />
        </div>
        <button type="submit">Create</button>
      </form>
    </div>
  );
};

export default ProductCreateForm;
