import { useNavigate } from 'react-router-dom';
import { useCart } from './CartContext';

function CartPage() {
  const { cart, removeFromCart, updateQuantity, totalPrice } = useCart();
  const navigate = useNavigate();

  const handleContinueShopping = () => {
    const returnUrl = sessionStorage.getItem('returnUrl') || '/';
    navigate(returnUrl);
  };

  if (cart.length === 0) {
    return (
      <div className="container text-center mt-5">
        <h2>Your Cart is Empty</h2>
        <p className="text-muted">Add some books to get started!</p>
        <button
          className="btn btn-primary mt-3"
          onClick={handleContinueShopping}
        >
          Continue Shopping
        </button>
      </div>
    );
  }

  return (
    <div className="container">
      <h2 className="mb-4">Shopping Cart</h2>

      {/* Bootstrap Table with striped rows (#notcoveredinthevideos Feature #2 - Table with hover effect) */}
      <div className="table-responsive">
        <table className="table table-striped table-hover align-middle">
          <thead className="table-dark">
            <tr>
              <th>Book</th>
              <th>Author</th>
              <th className="text-center">Price</th>
              <th className="text-center" style={{ width: '150px' }}>
                Quantity
              </th>
              <th className="text-end">Subtotal</th>
              <th className="text-center">Actions</th>
            </tr>
          </thead>
          <tbody>
            {cart.map((item) => (
              <tr key={item.book.bookId}>
                <td>
                  <strong>{item.book.title}</strong>
                  <br />
                  <span className="badge bg-primary">{item.book.category}</span>
                </td>
                <td>{item.book.author}</td>
                <td className="text-center">
                  ${item.book.price.toFixed(2)}
                </td>
                <td className="text-center">
                  {/* Bootstrap Input Group (#notcoveredinthevideos - input group with buttons) */}
                  <div className="input-group input-group-sm justify-content-center">
                    <button
                      className="btn btn-outline-secondary"
                      onClick={() =>
                        updateQuantity(item.book.bookId, item.quantity - 1)
                      }
                    >
                      -
                    </button>
                    <span
                      className="input-group-text bg-white"
                      style={{ minWidth: '40px', justifyContent: 'center' }}
                    >
                      {item.quantity}
                    </span>
                    <button
                      className="btn btn-outline-secondary"
                      onClick={() =>
                        updateQuantity(item.book.bookId, item.quantity + 1)
                      }
                    >
                      +
                    </button>
                  </div>
                </td>
                <td className="text-end fw-bold">
                  ${(item.book.price * item.quantity).toFixed(2)}
                </td>
                <td className="text-center">
                  <button
                    className="btn btn-danger btn-sm"
                    onClick={() => removeFromCart(item.book.bookId)}
                  >
                    Remove
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
          <tfoot>
            <tr className="table-success">
              <td colSpan="4" className="text-end fs-5 fw-bold">
                Total:
              </td>
              <td className="text-end fs-5 fw-bold">
                ${totalPrice.toFixed(2)}
              </td>
              <td></td>
            </tr>
          </tfoot>
        </table>
      </div>

      <div className="d-flex justify-content-between mt-3">
        <button
          className="btn btn-outline-primary"
          onClick={handleContinueShopping}
        >
          &larr; Continue Shopping
        </button>
        <button className="btn btn-success" disabled>
          Checkout
        </button>
      </div>
    </div>
  );
}

export default CartPage;
