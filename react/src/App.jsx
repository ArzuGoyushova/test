import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import ProductList from './components/ProductList';
import CategoryList from './components/CategoryList';
import CategoryDetail from './components/CategoryDetail';
import ProductDetail from './components/ProductDetail';
import ProductCreateForm from './components/ProductCreateForm'; // Import the new component


function App() {
  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/products">Products</Link>
            </li>
            <li>
              <Link to="/categories">Categories</Link>
            </li>
            <li>
              <Link to="/create-product">Create</Link>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path="/products" element={<ProductList />} />
          <Route path="/categories" element={<CategoryList />} />
          <Route path="/categories/:id" element={<CategoryDetail />} /> 
          <Route path="/products/:id" element={<ProductDetail />} /> 
          <Route path="/create-product" element={<ProductCreateForm />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
