let content;
let showCode;
let filename;
let textData = "";

let active = false;

document.onload = function () {
	content = document.getElementById('content');
	showCode = document.getElementById('show-code');
	filename = document.getElementById('filename');

	

	content.addEventListener('mouseenter', function () {
		const a = content.querySelectorAll('a');
		a.forEach(item => {
			item.addEventListener('mouseenter', function () {
				content.setAttribute('contenteditable', false);
				item.target = '_blank';
			});
			item.addEventListener('mouseleave', function () {
				content.setAttribute('contenteditable', true);
			});
		})
	});

	showCode.addEventListener('click', function () {
		showCode.dataset.active = !active;
		active = !active
		if (active) {
			content.textContent = content.innerHTML;
			content.setAttribute('contenteditable', false);
		} else {
			content.innerHTML = content.textContent;
			content.setAttribute('contenteditable', true);
		}
	});
}

export function getData() {
	content = document.getElementById('content');

	return content.innerHTML;
}

export function setData(modelData) {
	content = document.getElementById('content');
	content.innerHTML = modelData;
}

export function formatDoc(cmd, value = null) {
	if (value) {
		document.execCommand(cmd, false, value);
	} else {
		document.execCommand(cmd);
	}
}

export function addLink() {
	const url = prompt('Insert url');
	formatDoc('createLink', url);
}


export function fileHandle(value, element) {
	content = document.getElementById('content');
	filename = document.getElementById('filename');

	if (value === 'new') {
		content.innerHTML = '';
		filename.value = 'untitled';
	} else if (value === 'txt') {
		const blob = new Blob([content.innerText])
		const url = URL.createObjectURL(blob)
		const link = document.createElement('a');
		link.href = url;
		link.download = `${filename.value}.txt`;
		link.click();
	}
}