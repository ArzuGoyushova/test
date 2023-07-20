import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const CategoryList = () => {
    const [categories, setCategories] = useState([]); // Initialize with an empty array
  
    useEffect(() => {
      axios.get('https://localhost:7032/api/category')
        .then((response) => {
          setCategories(response.data);
        })
        .catch((error) => {
          console.error(error);
        });
    }, []);
  
    return (
      <div>
        <h2>Category List</h2>
          <ul>
            {categories.map((category) => (
              <li key={category.id}>
                <Link to={`/categories/${category.id}`}>{category.name}</Link>
              </li>
            ))}
          </ul>
      </div>
    );
}

export default CategoryList;
