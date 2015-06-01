// Main app JS.

var Fibbage = React.createClass({
  render: function () {
    return (
      <JoinRoom/>
    );
  }
});

var JoinRoom = React.createClass({
  render: function () {
    return (
      <div>
        <TextInput label='Room'/>
        <TextInput label='Your Name' go='Join'/>
      </div>
    );
  }
});

var TextInput = React.createClass({
  propTypes: {
    label: React.PropTypes.string.isRequired,
    go: React.PropTypes.string
  },

  render: function () {
    return (
      <div>
        <label>
          {this.props.label}
          <input type='text'/>
        </label>
        {this.props.go ? <button>{this.props.go}</button> : ''}
      </div>
    );
  }
});

(function () {
  React.render(React.createElement(Fibbage, {}), document.querySelector('#reactify'));
})();
