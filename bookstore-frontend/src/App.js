import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { CartProvider } from './CartContext';
import Navbar from './Navbar';
import BookList from './BookList';
import CartPage from './CartPage';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import './App.css';

function App() {
  return (
    <CartProvider>
      <Router>
        <div className="App">
          <Navbar />
          <Routes>
            <Route path="/" element={<BookList />} />
            <Route path="/cart" element={<CartPage />} />
          </Routes>
          <footer className="text-center text-muted py-4 mt-5 border-top">
            <small>IS 413 - Bookstore Project - Mission #12</small>
          </footer>
        </div>
      </Router>
    </CartProvider>
  );
}

export default App;
