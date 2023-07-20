import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

const CategoryDetail = () => {
  const { id } = useParams();
  const [category, setCategory] = useState(null);

  useEffect(() => {
    axios.get(`https://localhost:7032/api/category/${id}`)
      .then((response) => {
        setCategory(response.data);
      })
      .catch((error) => {
        console.error(error);
      });
  }, [id]); // Use `id` from useParams directly, no need for match.params.id

  if (!category) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h2>Category Details</h2>
      <ul>
        <li key={category.id}>
          <p>Category name: {category.name}</p>
          <p>Category Image: {category.imageUrl}</p>
        </li>
      </ul>
    </div>
  );
};

export default CategoryDetail;
