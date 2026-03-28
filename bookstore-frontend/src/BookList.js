import { useState, useMemo } from 'react';
import { useSearchParams, useNavigate } from 'react-router-dom';
import books from './booksData';
import { useCart } from './CartContext';
import CartSummary from './CartSummary';

const ITEMS_PER_PAGE = 5;

function BookList() {
  const [searchParams, setSearchParams] = useSearchParams();
  const navigate = useNavigate();
  const { addToCart } = useCart();
  const [addedBookId, setAddedBookId] = useState(null);

  const currentCategory = searchParams.get('category') || '';
  const currentPage = parseInt(searchParams.get('page') || '1', 10);

  const categories = useMemo(
    () => [...new Set(books.map((b) => b.category))].sort(),
    []
  );

  const filteredBooks = useMemo(
    () =>
      currentCategory
        ? books.filter((b) => b.category === currentCategory)
        : books,
    [currentCategory]
  );

  const totalPages = Math.ceil(filteredBooks.length / ITEMS_PER_PAGE);
  const safePage = Math.min(Math.max(1, currentPage), totalPages || 1);
  const paginatedBooks = filteredBooks.slice(
    (safePage - 1) * ITEMS_PER_PAGE,
    safePage * ITEMS_PER_PAGE
  );

  const setCategory = (cat) => {
    const params = {};
    if (cat) params.category = cat;
    params.page = '1';
    setSearchParams(params);
  };

  const setPage = (page) => {
    const params = { page: String(page) };
    if (currentCategory) params.category = currentCategory;
    setSearchParams(params);
  };

  const handleAddToCart = (book) => {
    addToCart(book);
    setAddedBookId(book.bookId);
    setTimeout(() => setAddedBookId(null), 1500);
  };

  const handleAddAndGoToCart = (book) => {
    addToCart(book);
    // Save current location so "Continue Shopping" can return here
    const returnUrl = `/?${searchParams.toString()}`;
    sessionStorage.setItem('returnUrl', returnUrl);
    navigate('/cart');
  };

  return (
    <div className="container">
      <div className="row">
        {/* Category Sidebar */}
        <div className="col-lg-3 col-md-4 mb-4">
          <CartSummary />

          {/* Bootstrap Accordion for categories (#notcoveredinthevideos Feature #1) */}
          <div className="accordion mt-3" id="categoryAccordion">
            <div className="accordion-item">
              <h2 className="accordion-header">
                <button
                  className="accordion-button"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#categoryCollapse"
                  aria-expanded="true"
                  aria-controls="categoryCollapse"
                >
                  Filter by Category
                </button>
              </h2>
              <div
                id="categoryCollapse"
                className="accordion-collapse collapse show"
                data-bs-parent="#categoryAccordion"
              >
                <div className="accordion-body p-0">
                  <div className="list-group list-group-flush">
                    <button
                      className={`list-group-item list-group-item-action ${
                        !currentCategory ? 'active' : ''
                      }`}
                      onClick={() => setCategory('')}
                    >
                      All Categories
                      <span className="badge bg-secondary float-end">
                        {books.length}
                      </span>
                    </button>
                    {categories.map((cat) => (
                      <button
                        key={cat}
                        className={`list-group-item list-group-item-action ${
                          currentCategory === cat ? 'active' : ''
                        }`}
                        onClick={() => setCategory(cat)}
                      >
                        {cat}
                        <span className="badge bg-secondary float-end">
                          {books.filter((b) => b.category === cat).length}
                        </span>
                      </button>
                    ))}
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        {/* Book List */}
        <div className="col-lg-9 col-md-8">
          <h2 className="mb-3">
            {currentCategory || 'All Books'}
            <span className="badge bg-info ms-2 fs-6">
              {filteredBooks.length} book{filteredBooks.length !== 1 ? 's' : ''}
            </span>
          </h2>

          <div className="row">
            {paginatedBooks.map((book) => (
              <div key={book.bookId} className="col-12 mb-3">
                <div className="card shadow-sm">
                  <div className="card-body">
                    <div className="row align-items-center">
                      <div className="col-md-8">
                        <h5 className="card-title mb-1">{book.title}</h5>
                        <p className="card-text text-muted mb-1">
                          by {book.author}
                        </p>
                        <p className="card-text mb-1">
                          <small>
                            {book.publisher} | {book.pageCount} pages | ISBN:{' '}
                            {book.isbn}
                          </small>
                        </p>
                        <span className="badge bg-primary me-1">
                          {book.category}
                        </span>
                        <span className="badge bg-secondary">
                          {book.classification}
                        </span>
                      </div>
                      <div className="col-md-4 text-md-end mt-2 mt-md-0">
                        <p className="fs-4 fw-bold text-success mb-2">
                          ${book.price.toFixed(2)}
                        </p>
                        <button
                          className="btn btn-primary btn-sm me-1"
                          onClick={() => handleAddToCart(book)}
                        >
                          {addedBookId === book.bookId
                            ? 'Added!'
                            : 'Add to Cart'}
                        </button>
                        <button
                          className="btn btn-outline-primary btn-sm"
                          onClick={() => handleAddAndGoToCart(book)}
                        >
                          Buy Now
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>

          {/* Pagination */}
          {totalPages > 1 && (
            <nav aria-label="Book pagination" className="mt-3">
              <ul className="pagination justify-content-center">
                <li
                  className={`page-item ${safePage === 1 ? 'disabled' : ''}`}
                >
                  <button
                    className="page-link"
                    onClick={() => setPage(safePage - 1)}
                  >
                    Previous
                  </button>
                </li>
                {Array.from({ length: totalPages }, (_, i) => i + 1).map(
                  (page) => (
                    <li
                      key={page}
                      className={`page-item ${
                        page === safePage ? 'active' : ''
                      }`}
                    >
                      <button
                        className="page-link"
                        onClick={() => setPage(page)}
                      >
                        {page}
                      </button>
                    </li>
                  )
                )}
                <li
                  className={`page-item ${
                    safePage === totalPages ? 'disabled' : ''
                  }`}
                >
                  <button
                    className="page-link"
                    onClick={() => setPage(safePage + 1)}
                  >
                    Next
                  </button>
                </li>
              </ul>
            </nav>
          )}
        </div>
      </div>
    </div>
  );
}

export default BookList;
