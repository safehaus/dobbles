// Main app JS.

var api = (function () {

  var data = {};

  return {
    room: {
      join: function (name, roomCode) {
        data.name = name;
        data.roomCode = roomCode;
      }
    },
    data: data
  }
})();

var Fibbage = React.createClass({
  render: function () {
    return (
      <JoinRoom/>
    );
  }
});

var JoinRoom = React.createClass({
  render: function () {
    var join = function () {
      api.room.join(this.refs.name.getText(), this.refs.room.getText());
    }.bind(this);

    return (
      <div>
        <TextInput label='Room' ref='room'/>
        <TextInput label='Your Name' go='Join' action={join} ref='name'/>
      </div>
    );
  }
});

var TextInput = React.createClass({
  propTypes: {
    label: React.PropTypes.string.isRequired,
    go: React.PropTypes.string,
    action: React.PropTypes.func
  },

  getText: function () {
    return React.findDOMNode(this.refs.text).value;
  },

  render: function () {
    return (
      <div>
        <label>
          {this.props.label}
          <input type='text' ref='text'/>
        </label>
        {this.props.go ? <button onClick={this.props.action}>{this.props.go}</button> : ''}
      </div>
    );
  }
});

(function () {
  React.render(React.createElement(Fibbage, {}), document.querySelector('#reactify'));
})();
